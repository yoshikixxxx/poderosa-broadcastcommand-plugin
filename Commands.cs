/*
 * Copyright 2015-2016 yoshikixxxx.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 */
using System.Threading;
using System.Collections;

using Poderosa.Sessions;
using Poderosa.Commands;

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

        /// <summary>
        /// 画面バッファクリア
        /// </summary>
        public void SendClearBuffer(ArrayList terminalSession) {
            foreach (ITerminalSession ts in terminalSession) {
                // 対象セッションをアクティブ(アクティブにしていない状態で実行すると強制終了される)
                BroadcastCommandPlugin.Instance.SessionManager.ActivateDocument(ts.Terminal.IDocument, ActivateReason.InternalAction);

                ICommandTarget ct = (ICommandTarget)ts.TerminalControl.GetAdapter(typeof(ICommandTarget));
                if (ct != null) {
                    ICommandManager cm = BroadcastCommandPlugin.Instance.CommandManager;
                    cm.Execute(cm.Find("org.poderosa.terminalemulator.clearbuffer"), ct);
                    ts.TerminalTransmission.SendLineBreak(); // クリア後に改行送信
                }
            }
        }

        /// <summary>
        /// 改行送信
        /// </summary>
        public void SendLineBreak(ArrayList terminalSession) {
            foreach (ITerminalSession ts in terminalSession) {
                ts.TerminalTransmission.SendLineBreak();
            }
        }

        /// <summary>
        /// Ctrl+C送信
        /// </summary>
        public void SendCtrlC(ArrayList terminalSession) {
            byte[] bytes = { (byte)0x03 }; // CtrlC=ETX=0x03

            foreach (ITerminalSession ts in terminalSession) {
                ts.TerminalTransmission.Transmit(bytes);
            }
        }
    }
}
