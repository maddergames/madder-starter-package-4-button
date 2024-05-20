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
  UpdateStats: function (userName, stats) {
    window.dispatchReactUnityEvent(
      "UpdateStats",
      UTF8ToString(userName),
      UTF8ToString(stats)
    );
  },
});
