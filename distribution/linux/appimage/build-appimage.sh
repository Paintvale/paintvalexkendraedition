#!/bin/sh
set -eu

ROOTDIR="$(readlink -f "$(dirname "$0")")"/../../../
cd "$ROOTDIR"

BUILDDIR=${BUILDDIR:-publish}
OUTDIR=${OUTDIR:-publish_appimage}
UFLAG=${UFLAG:-"gh-releases-zsync|Kpatrparemoveshellandbeinfrontofbushtorelievehimself|paintvale|latest|*-x64.AppImage.zsync"}

rm -rf AppDir
mkdir -p AppDir/usr/bin

cp distribution/linux/Paintvale.desktop AppDir/Paintvale.desktop
cp distribution/linux/appimage/AppRun AppDir/AppRun
cp distribution/misc/Logo.svg AppDir/Paintvale.svg


cp -r "$BUILDDIR"/* AppDir/usr/bin/

# Ensure necessary bins are set as executable
chmod +x AppDir/AppRun AppDir/usr/bin/Paintvale*

mkdir -p "$OUTDIR"

appimagetool --comp zstd --mksquashfs-opt -Xcompression-level --mksquashfs-opt 21 \
    -u "$UFLAG" \
    AppDir "$OUTDIR"/Paintvale.AppImage

# Move zsync file needed for delta updates
if [ "$RELEASE" = "1" ]; then
    mv ./*.AppImage.zsync "$OUTDIR"
fi
