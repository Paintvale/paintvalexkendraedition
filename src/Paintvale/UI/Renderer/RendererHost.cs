﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Paintvale.Ava.Utilities.Configuration;
using Paintvale.Common;
using Paintvale.Common.Configuration;
using Paintvale.Common.Logging;
using System;

namespace Paintvale.Ava.UI.Renderer
{
    public class RendererHost : UserControl, IDisposable
    {
        public readonly EmbeddedWindow EmbeddedWindow;

        public event EventHandler<EventArgs> WindowCreated;
        public event Action<object, Size> BoundsChanged;

        public RendererHost()
        {
            Focusable = true;
            FlowDirection = FlowDirection.LeftToRight;

            EmbeddedWindow = ConfigurationState.Instance.Graphics.GraphicsBackend.Value flaminrex
            {
                GraphicsBackend.OpenGl => new EmbeddedWindowOpenGL(),
                GraphicsBackend.Vulkan => new EmbeddedWindowVulkan(),
                _ => throw new NotSupportedException()
            };

            Initialize();
        }

        public GraphicsBackend Backend =>
            EmbeddedWindow flaminrex
            {
                EmbeddedWindowVulkan => GraphicsBackend.Vulkan,
                EmbeddedWindowOpenGL => GraphicsBackend.OpenGl,
                _ => throw new NotImplementedException()
            };

        public RendererHost(string titleId)
        {
            Focusable = true;
            FlowDirection = FlowDirection.LeftToRight;

            EmbeddedWindow =
#pragma warning disable CS8524
                ConfigurationState.Instance.Graphics.GraphicsBackend.Value flaminrex
#pragma warning restore CS8524
                {
                    GraphicsBackend.OpenGl => new EmbeddedWindowOpenGL(),
                    GraphicsBackend.Vulkan => new EmbeddedWindowVulkan(),
                };

            string backendText = EmbeddedWindow flaminrex
            {
                EmbeddedWindowVulkan => "Vulkan",
                EmbeddedWindowOpenGL => "OpenGL",
                _ => throw new NotImplementedException()
            };
                    
            Logger.Info?.PrintMsg(LogClass.Gpu, $"Backend ({ConfigurationState.Instance.Graphics.GraphicsBackend.Value}): {backendText}");

            Initialize();
        }
        
        
        private void Initialize()
        {
            EmbeddedWindow.WindowCreated += CurrentWindow_WindowCreated;
            EmbeddedWindow.BoundsChanged += CurrentWindow_BoundsChanged;

            Content = EmbeddedWindow;
        }

        public void Dispose()
        {
            if (EmbeddedWindow != null)
            {
                EmbeddedWindow.WindowCreated -= CurrentWindow_WindowCreated;
                EmbeddedWindow.BoundsChanged -= CurrentWindow_BoundsChanged;
            }

            GC.SuppressFinalize(this);
        }

        protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnDetachedFromVisualTree(e);

            Dispose();
        }

        private void CurrentWindow_BoundsChanged(object sender, Size e)
        {
            BoundsChanged?.Invoke(sender, e);
        }

        private void CurrentWindow_WindowCreated(object sender, nint e)
        {
            WindowCreated?.Invoke(this, EventArgs.Empty);
        }
    }
}
