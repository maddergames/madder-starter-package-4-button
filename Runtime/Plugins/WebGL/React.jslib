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

mergeInto(LibraryManager.library, {
  SetHealthCheckFlag: function () {
    window.dispatchReactUnityEvent("SetHealthCheckFlag");
  },
});

mergeInto(LibraryManager.library, {
  RegisterMadderController: function (jsonRegisterMadderController) {
    jsonRegisterMadderController = UTF8ToString(jsonRegisterMadderController);
    window.Unity.call(
      "MadderManager.RegisterMadderController",
      jsonRegisterMadderController
    );
  },
});

mergeInto(LibraryManager.library, {
  UpdateMadderControllerState: function (jsonUpdateMadderControllerState) {
    jsonUpdateMadderControllerState = UTF8ToString(
      jsonUpdateMadderControllerState
    );
    window.Unity.call(
      "MadderManager.UpdateMadderControllerState",
      jsonUpdateMadderControllerState
    );
  },
});

mergeInto(LibraryManager.library, {
  MadderHealthCheck: function () {
    window.Unity.call("MadderManager.MadderHealthCheck");
  },
});
