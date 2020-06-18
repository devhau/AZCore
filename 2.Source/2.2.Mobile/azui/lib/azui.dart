import 'dart:async';

import 'package:flutter/services.dart';

class Azui {
  static const MethodChannel _channel =
      const MethodChannel('azui');

  static Future<String> get platformVersion async {
    final String version = await _channel.invokeMethod('getPlatformVersion');
    return version;
  }
}
