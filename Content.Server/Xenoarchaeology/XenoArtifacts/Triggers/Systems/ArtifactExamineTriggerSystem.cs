// SPDX-FileCopyrightText: 2022 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Tayrtahn <tayrtahn@gmail.com>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
//
// SPDX-License-Identifier: MIT

using Content.Server.Xenoarchaeology.XenoArtifacts.Triggers.Components;
using Content.Shared.Examine;
using Content.Shared.Ghost;

namespace Content.Server.Xenoarchaeology.XenoArtifacts.Triggers.Systems;

public sealed class ArtifactExamineTriggerSystem : EntitySystem
{
    [Dependency] private readonly ArtifactSystem _artifact = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        SubscribeLocalEvent<ArtifactExamineTriggerComponent, ExaminedEvent>(OnExamine);
    }

    private void OnExamine(EntityUid uid, ArtifactExamineTriggerComponent component, ExaminedEvent args)
    {
        // Prevent ghosts from activating this trigger unless they have CanGhostInteract
        if (TryComp<GhostComponent>(args.Examiner, out var ghost) && !ghost.CanGhostInteract)
            return;

        _artifact.TryActivateArtifact(uid);
    }
}