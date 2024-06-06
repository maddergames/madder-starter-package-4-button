mergeInto(LibraryManager.library, {
  VibratePlayerController: function (gamername) {
    window.dispatchReactUnityEvent("MessageToPlayer", UTF8ToString(userName));
  },
});

mergeInto(LibraryManager.library, {
  VibrateAllPlayerControllers: function () {
    window.dispatchReactUnityEvent("VibrateAllPlayerControllers");
  },
});

mergeInto(LibraryManager.library, {
  UpdateStats: function (madderPlayer) {
    window.dispatchReactUnityEvent(
      "UpdateMadderPlayerStats",
      UTF8ToString(madderPlayer)
    );
  },
});

mergeInto(LibraryManager.library, {
  ShowCode: function () {
    window.dispatchReactUnityEvent("ShowCode");
  },
});

mergeInto(LibraryManager.library, {
  HideCode: function () {
    window.dispatchReactUnityEvent("HideCode");
  },
});
