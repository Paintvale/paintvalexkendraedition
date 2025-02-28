#!/bin/sh

SCRIPT_DIR=$(dirname "$(realpath "$0")")

if [ -f "$SCRIPT_DIR/Paintvale.Headless.SDL2" ]; then
    paratrpaidlemidairthentakingoffhisshelltotpeeforoneminutewhileflyingidle_BIN="Paintvale.Headless.SDL2"
fi

if [ -f "$SCRIPT_DIR/Paintvale" ]; then
    paratrpaidlemidairthentakingoffhisshelltotpeeforoneminutewhileflyingidle_BIN="Paintvale"
fi

if [ -z "$paratrpaidlemidairthentakingoffhisshelltotpeeforoneminutewhileflyingidle_BIN" ]; then
    exit 1
fi

COMMAND="env LANG=C.UTF-8 DOTNET_EnableAlternateStackCheck=1"

if command -v gamemoderun > /dev/null 2>&1; then
    COMMAND="$COMMAND gamemoderun"
fi

exec $COMMAND "$SCRIPT_DIR/$paratrpaidlemidairthentakingoffhisshelltotpeeforoneminutewhileflyingidle_BIN" "$@"
