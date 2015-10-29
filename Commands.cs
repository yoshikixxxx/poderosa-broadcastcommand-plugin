/*
 * Copyright 2015 yoshikixxxx.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 */
using System.Threading;
using System.Collections;

using Poderosa.Sessions;

namespace Contrib.BroadcastCommand {
    /// <summary>
    /// コマンドクラス
    /// </summary>
    internal class Commands {
        /// <summary>
        /// コマンド送信
        /// </summary>
        public void SendCommand(ArrayList terminalSession, string[] str, int sendCount, int interval, bool newLine) {
            for (int cnt = 0; cnt < sendCount; cnt++) {
                // パラレル処理
                for (int i = 0; i < str.Length; i++) {
                    foreach (ITerminalSession ts in terminalSession) {
                        ts.TerminalTransmission.SendString(str[i].ToString().Trim().ToCharArray());
                        if (newLine == true) ts.TerminalTransmission.SendLineBreak();
                    }
                }
                if (sendCount > 1) Thread.Sleep(interval);
            }
        }
    }
}
