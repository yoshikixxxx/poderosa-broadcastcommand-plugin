/*
 * Copyright 2015-2016 yoshikixxxx.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 */
using System;
using System.Collections;
using System.Windows.Forms;
using System.Threading;

using Poderosa.Forms;
using Poderosa.Sessions;

namespace Contrib.BroadcastCommand {
    /// <summary>
    /// BroadcastCommandメインフォームクラス
    /// </summary>
    public partial class BroadcastCommandForm : Form {
        // メンバー変数
        private const int FORM_WIDTH_LOG_SHOW = 620;
        private const int FORM_WIDTH_LOG_HIDE = 356;
        private const string STR_SEPARATE = "**************************************";
        private Commands _cmd = new Commands();
        private ListViewItemComparer _listViewItemSorter;
        private IPoderosaMainWindow _window;
        private ArrayList _selectSessions = new ArrayList();
        private ArrayList _selectSessionsHash = new ArrayList();
        private bool _Initialized = false;
        private bool _allSelectFlg = false;
        private bool _cancelFlg = false;
        private bool _sendingFlg = false;
        private bool _firstSendFlg = true;
        private bool _refreshingFlg = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BroadcastCommandForm(IPoderosaMainWindow window) {
            _window = window;
            InitializeComponent();
            InitializeComponentValue();

            RefreshSessionList();
            if (_sessionListView.Items.Count > 0) {
                _sessionListView.Items[0].Selected = true;
            }

            _Initialized = true;
        }

        /// <summary>
        /// オブジェクト各値設定
        /// </summary>
        private void InitializeComponentValue() {
            // テキスト
            this.Text = BroadcastCommandPlugin.Strings.GetString("Caption.BroadcastCommand");
            this._okButton.Text = BroadcastCommandPlugin.Strings.GetString("Common.OK");
            this._cancelButton.Text = BroadcastCommandPlugin.Strings.GetString("Common.Cancel");
            this._logButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._logButton.Show");
            this._refreshListButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._refreshListButton");
            this._commandClearButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._commandClearButton");
            this._listAllSelectButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._listAllSelectButton.Check");
            this._repeatCountLabel.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._repeatCountLabel");
            this._repeatIntervalLabel.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._repeatIntervalLabel");
            this._tabNumberColumn.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._tabNumberColumn");
            this._hostNameColumn.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._hostNameColumn");
            this._alwaysOnTopCheck.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._alwaysOnTopCheck");
            this._notSendNewLineCheck.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._notSendNewLine");
            this._clearBufferButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._clearBufferButton");
            this._sendNewLineButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._sendNewLineButton");
            this._sendCtrlCButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._sendCtrlCButton");

            // デフォルト値
            this.Width = FORM_WIDTH_LOG_HIDE;
            this._logBox.Visible = false;
            this._commandBox.Clear();
            this._okButton.Enabled = false;
            this._clearBufferButton.Enabled = false;
            this._sendNewLineButton.Enabled = false;
            this._sendCtrlCButton.Enabled = false;
            this._repeatCountBox.Value = 1;
            this._repeatIntervalBox.Value = 1000;
            this._repeatIntervalBox.Enabled = false;
            this._alwaysOnTopCheck.Checked = true;

            // セッションリストカラム幅
            this._tabNumberColumn.Width = -2;
            this._hostNameColumn.Width = -2;

            // セッションリストソートイベント作成/設定
            _listViewItemSorter = new ListViewItemComparer();
            _listViewItemSorter.ColumnModes = new ListViewItemComparer.ComparerMode[] {
                ListViewItemComparer.ComparerMode.Integer,
                ListViewItemComparer.ComparerMode.String,
            };
            _sessionListView.ListViewItemSorter = _listViewItemSorter;
        }

        /// <summary>
        /// セッションリスト更新
        /// </summary>
        private void RefreshSessionList() {
            _refreshingFlg = true;
            _sessionListView.BeginUpdate();
            _sessionListView.Items.Clear();

            ISessionManager sm = BroadcastCommandPlugin.Instance.GetSessionManager();
            IPoderosaDocument[] docs = sm.GetDocuments(_window);
            IWindowManager wm = (IWindowManager)BroadcastCommandPlugin.Instance.WindowManager;
            int docCnt = wm.ActiveWindow.DocumentTabFeature.DocumentCount;
            for (int i = 0; i < docCnt; i++) {
                IPoderosaDocument doc = wm.ActiveWindow.DocumentTabFeature.GetAtOrNull(i);
                int hash = doc.GetHashCode();

                // リストオブジェクト作成
                ListViewItem li = new ListViewItem();

                // データ代入
                li.Text = (i + 1).ToString(); // タブ番号
                li.SubItems.Add(doc.Caption); // ホスト名

                foreach (int tmphash in _selectSessionsHash) {
                    if (tmphash == hash) {
                        li.Checked = true;
                        break;
                    }
                }

                // タグ追加
                li.Tag = doc;

                // アイテム追加
                _sessionListView.Items.Add(li);
            }
            _sessionListView.EndUpdate();
            _sessionListView.SelectedItems.Clear();
            _refreshingFlg = false;

            // 全選択ボタン有効/無効化
            _listAllSelectButton.Enabled = _sessionListView.Items.Count > 0 ? true : false;
        }

        /// <summary>
        /// 選択済セッション取得
        /// </summary>
        private string GetSelectedSessionList() {
            string Str = "";

            _selectSessions.Clear();
            foreach (ListViewItem li in _sessionListView.CheckedItems) {
                IPoderosaDocument doc = li.Tag as IPoderosaDocument;
                ITerminalSession ts = (ITerminalSession)doc.OwnerSession.GetAdapter(typeof(ITerminalSession));
                if (ts != null) {
                    _selectSessions.Add(ts);
                    Str += ts.Caption + " ";
                }
            }
            return Str.Trim();
        }

        /// <summary>
        /// OKボタンイベント
        /// </summary>
        private void _okButton_Click(object sender, EventArgs e) {
            // 改行のみは送信しない
            if (_commandBox.Text.Trim() != "") {
                // オブジェクト有効/無効化
                _sendingFlg = true;
                _commandBox.ReadOnly = true;
                _okButton.Enabled = false;
                _listAllSelectButton.Enabled = false;
                _repeatCountBox.Enabled = false;
                _repeatIntervalBox.Enabled = false;
                _sessionListView.Enabled = false;

                // 選択セッションを配列に格納
                string selectSessionStr = GetSelectedSessionList();

                // ログ出力
                string logStr = "";
                if (_firstSendFlg == true) {
                    logStr = STR_SEPARATE + "\r\n";
                    _firstSendFlg = false;
                }
                logStr += "[" + DateTime.Now.ToString() + "]\r\n";
                logStr += "* Session  : " + selectSessionStr + "\r\n";
                logStr += "* Count    : " + _repeatCountBox.Value.ToString() + "\r\n";
                logStr += "* Interval : " + _repeatIntervalBox.Value.ToString() + "\r\n";
                logStr += _commandBox.Text + "\r\n";
                logStr += STR_SEPARATE + "\r\n";
                _logBox.AppendText(logStr);

                // コマンド送信スレッド作成
                Thread _sendCommandThread = new Thread((ThreadStart)delegate() {
                    _cmd.SendCommand(_selectSessions, _commandBox.Lines, (int)_repeatCountBox.Value, (int)_repeatIntervalBox.Value, !_notSendNewLineCheck.Checked);
                });
                _sendCommandThread.IsBackground = true;
                _sendCommandThread.Start();

                // スレッド終了/キャンセル待機
                while (true) {
                    Thread.Sleep(10);
                    if (_cancelFlg == true) _sendCommandThread.Abort(); // 接続キャンセル(スレッド終了)
                    if (_sendCommandThread.IsAlive != true) break; // スレッド終了後break
                    System.Windows.Forms.Application.DoEvents();
                }

                // オブジェクト有効/無効化
                _commandBox.Clear();
                _commandBox.ReadOnly = false;
                _cancelFlg = false;
                _sendingFlg = false;
                _okButton.Enabled = true;
                _listAllSelectButton.Enabled = true;
                _repeatCountBox.Enabled = true;
                _repeatIntervalBox.Enabled = _repeatCountBox.Value > 1 ? true : false;
                _sessionListView.Enabled = true;

                // セッションリスト更新/更新後コマンドボックスにフォーカス
                Thread.Sleep(100);
                RefreshSessionList();
                _commandBox.Focus();
            }
        }

        /// <summary>
        /// キャンセルボタンイベント
        /// </summary>
        private void _cancelButton_Click(object sender, EventArgs e) {
            if (_sendingFlg == true) {
                _cancelFlg = true;
            } else {
                this.Close();
            }
        }

        /// <summary>
        /// クリアボタンイベント
        /// </summary>
        private void _commandClearButton_Click(object sender, EventArgs e) {
            _commandBox.Clear();
        }

        /// <summary>
        /// バッファクリアボタンイベント
        /// </summary>
        private void _clearBufferButton_Click(object sender, EventArgs e) {
            // 選択セッションを配列に格納
            string selectSessionStr = GetSelectedSessionList();

            // コマンド送信スレッド作成
            Thread _sendCommandThread = new Thread((ThreadStart)delegate() {
                _cmd.SendClearBuffer(_selectSessions);
            });
            _sendCommandThread.IsBackground = true;
            _sendCommandThread.Start();
        }

        /// <summary>
        /// 改行送信ボタンイベント
        /// </summary>
        private void _sendNewLineButton_Click(object sender, EventArgs e) {
            // 選択セッションを配列に格納
            string selectSessionStr = GetSelectedSessionList();

            // コマンド送信スレッド作成
            Thread _sendCommandThread = new Thread((ThreadStart)delegate() {
                _cmd.SendLineBreak(_selectSessions);
            });
            _sendCommandThread.IsBackground = true;
            _sendCommandThread.Start();
        }

        /// <summary>
        /// Ctrl+C送信ボタンイベント
        /// </summary>
        private void _sendCtrlCButton_Click(object sender, EventArgs e) {
            // 選択セッションを配列に格納
            string selectSessionStr = GetSelectedSessionList();

            // コマンド送信スレッド作成
            Thread _sendCommandThread = new Thread((ThreadStart)delegate() {
                _cmd.SendCtrlC(_selectSessions);
            });
            _sendCommandThread.IsBackground = true;
            _sendCommandThread.Start();
        }

        /// <summary>
        /// リスト全選択/解除ボタンイベント
        /// </summary>
        private void _listAllSelectButton_Click(object sender, EventArgs e) {
            if (_allSelectFlg == true) {
                foreach (ListViewItem li in _sessionListView.Items) li.Checked = false;
                _listAllSelectButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._listAllSelectButton.Check");
            } else {
                foreach (ListViewItem li in _sessionListView.Items) li.Checked = true;
                _listAllSelectButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._listAllSelectButton.Uncheck");
            }
            _allSelectFlg = _allSelectFlg ? false : true;
        }

        /// <summary>
        /// リスト更新ボタンイベント
        /// </summary>
        private void _refreshListButton_Click(object sender, EventArgs e) {
            RefreshSessionList();
        }

        /// <summary>
        /// ログ表示ボタンイベント
        /// </summary>
        private void _logButton_Click(object sender, EventArgs e) {
            if (_logBox.Visible == true) {
                this.Width = FORM_WIDTH_LOG_HIDE;
                _logBox.Visible = false;
                _logButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._logButton.Show");
            } else {
                this.Width = FORM_WIDTH_LOG_SHOW;
                _logBox.Visible = true;
                _logButton.Text = BroadcastCommandPlugin.Strings.GetString("Form.BroadcastCommand._logButton.Hide");
            }
        }

        /// <summary>
        /// 繰り返し回数変更イベント
        /// </summary>
        private void _repeatCountBox_ValueChanged(object sender, EventArgs e) {
            _repeatIntervalBox.Enabled = _repeatCountBox.Value > 1 ? true : false;
        }

        /// <summary>
        /// 常に手前に表示チェックイベント
        /// </summary>
        private void _alwaysOnTopCheck_CheckedChanged(object sender, EventArgs e) {
            this.TopMost = _alwaysOnTopCheck.Checked;
        }

        /// <summary>
        /// コマンドボックスキー押下イベント
        /// </summary>
        private void _commandBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.A) {
                // Ctrl+A有効化
                _commandBox.SelectAll();
            } else if (!e.Shift && e.KeyCode == Keys.Enter && _okButton.Enabled == true) {
                _okButton_Click(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// ログボックスキー押下イベント
        /// </summary>
        private void _logBox_KeyDown(object sender, KeyEventArgs e) {
            // Ctrl+A有効化
            if (e.Control && e.KeyCode == Keys.A) _logBox.SelectAll();
        }

        /// <summary>
        /// セッションリストカラムクリックイベント
        /// </summary>
        private void _sessionListView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e) {
            _listViewItemSorter.Column = e.Column;
            _sessionListView.Sort();
        }

        /// <summary>
        /// セッションリストチェックボックスイベント
        /// </summary>
        private void _sessionListView_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (_Initialized == true) {
                // ボタン有効/無効化
                if (_sessionListView.CheckedItems.Count > 0) {
                    _okButton.Enabled = true;
                    _commandBox.Enabled = true;
                    _clearBufferButton.Enabled = true;
                    _sendNewLineButton.Enabled = true;
                    _sendCtrlCButton.Enabled = true;
                } else {
                    _okButton.Enabled = false;
                    _commandBox.Enabled = false;
                    _clearBufferButton.Enabled = false;
                    _sendNewLineButton.Enabled = false;
                    _sendCtrlCButton.Enabled = false;
                }

                // 選択済みリスト保存(リスト更新時復元用)
                if (_refreshingFlg == false) {
                    _selectSessionsHash.Clear();
                    foreach (ListViewItem li in _sessionListView.CheckedItems) {
                        IPoderosaDocument doc = li.Tag as IPoderosaDocument;
                        _selectSessionsHash.Add(doc.GetHashCode());
                    }
                }
            }
        }
    }




    /// <summary>
    /// ListViewカラムソートクラス
    /// </summary>
    public class ListViewItemComparer : IComparer {
        // メンバー変数
        public enum ComparerMode { String, Integer, DateTime };
        private int _column;
        private SortOrder _order;
        private ComparerMode _mode;
        private ComparerMode[] _columnModes;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="col">ソート列番号</param>
        /// <param name="ord">ソートオーダー</param>
        /// <param name="cmod">ソート方法</param>
        public ListViewItemComparer(int col, SortOrder ord, ComparerMode cmod) {
            _column = col;
            _order = ord;
            _mode = cmod;
        }
        public ListViewItemComparer() {
            _column = 0;
            _order = SortOrder.Ascending;
            _mode = ComparerMode.String;
        }

        /// <summary>
        /// ソート
        /// </summary>
        /// <param name="x">ListViewItem</param>
        /// <param name="y">ListViewItem</param>
        public int Compare(object x, object y) {
            int result = 0;
            ListViewItem itemx = (ListViewItem)x;
            ListViewItem itemy = (ListViewItem)y;

            if (_order == SortOrder.None) return 0;

            // ソート方法決定
            if (_columnModes != null && _columnModes.Length > _column) _mode = _columnModes[_column];

            // ソート方法別にxとyを比較
            switch (_mode) {
                case ComparerMode.String:   // 文字列
                    result = string.Compare(itemx.SubItems[_column].Text, itemy.SubItems[_column].Text);
                    break;
                case ComparerMode.Integer:  // 数値
                    result = int.Parse(itemx.SubItems[_column].Text).CompareTo(int.Parse(itemy.SubItems[_column].Text));
                    break;
                case ComparerMode.DateTime: // 日付
                    result = DateTime.Compare(DateTime.Parse(itemx.SubItems[_column].Text), DateTime.Parse(itemy.SubItems[_column].Text));
                    break;
            }

            // 降順時は結果を+-逆にする
            return (_order == SortOrder.Descending) ? -result : result;
        }

        /// <summary>
        /// ソート列番号
        /// </summary>
        public int Column {
            set {
                // 同一列の時は昇順降順をスイッチ
                if (_column == value) {
                    if (_order == SortOrder.Ascending) _order = SortOrder.Descending;
                    else if (_order == SortOrder.Descending) _order = SortOrder.Ascending;
                }
                _column = value;
            }
            get { return _column; }
        }
        /// <summary>
        /// ソートオーダー
        /// </summary>
        public SortOrder Order {
            set { _order = value; }
            get { return _order; }
        }
        /// <summary>
        /// ソート方法
        /// </summary>
        public ComparerMode Mode {
            set { _mode = value; }
            get { return _mode; }
        }
        /// <summary>
        /// 列毎のソート方法
        /// </summary>
        public ComparerMode[] ColumnModes {
            set { _columnModes = value; }
        }
    }
}
