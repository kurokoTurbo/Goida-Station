// SPDX-FileCopyrightText: 2025 Errant <35878406+Errant-4@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
//
// SPDX-License-Identifier: MIT

using Content.Shared.CCVar;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Options.UI.Tabs;

[GenerateTypedNameReferences]
public sealed partial class AdminOptionsTab : Control
{
    public AdminOptionsTab()
    {
        RobustXamlLoader.Load(this);

        Control.AddOptionCheckBox(CCVars.AdminOverlayClassic, EnableClassicOverlayCheckBox);

        Control.Initialize();
    }
}

