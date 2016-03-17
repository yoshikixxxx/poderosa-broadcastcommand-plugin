/*
 * Copyright 2015-2016 yoshikixxxx.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 */
namespace Contrib.BroadcastCommand {
    partial class BroadcastCommandForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this._sessionListView = new System.Windows.Forms.ListView();
            this._tabNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._hostNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._commandBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._repeatCountLabel = new System.Windows.Forms.Label();
            this._repeatCountBox = new System.Windows.Forms.NumericUpDown();
            this._repeatIntervalBox = new System.Windows.Forms.NumericUpDown();
            this._repeatIntervalLabel = new System.Windows.Forms.Label();
            this._logButton = new System.Windows.Forms.Button();
            this._logBox = new System.Windows.Forms.TextBox();
            this._refreshListButton = new System.Windows.Forms.Button();
            this._commandClearButton = new System.Windows.Forms.Button();
            this._listAllSelectButton = new System.Windows.Forms.Button();
            this._alwaysOnTopCheck = new System.Windows.Forms.CheckBox();
            this._notSendNewLineCheck = new System.Windows.Forms.CheckBox();
            this._clearBufferButton = new System.Windows.Forms.Button();
            this._sendNewLineButton = new System.Windows.Forms.Button();
            this._sendCtrlCButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._repeatCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._repeatIntervalBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _sessionListView
            // 
            this._sessionListView.AllowColumnReorder = true;
            this._sessionListView.CheckBoxes = true;
            this._sessionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._tabNumberColumn,
            this._hostNameColumn});
            this._sessionListView.FullRowSelect = true;
            this._sessionListView.GridLines = true;
            this._sessionListView.Location = new System.Drawing.Point(1, 317);
            this._sessionListView.MultiSelect = false;
            this._sessionListView.Name = "_sessionListView";
            this._sessionListView.ShowItemToolTips = true;
            this._sessionListView.Size = new System.Drawing.Size(340, 109);
            this._sessionListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._sessionListView.TabIndex = 0;
            this._sessionListView.UseCompatibleStateImageBehavior = false;
            this._sessionListView.View = System.Windows.Forms.View.Details;
            this._sessionListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._sessionListView_ColumnClick);
            this._sessionListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this._sessionListView_ItemChecked);
            // 
            // _tabNumberColumn
            // 
            this._tabNumberColumn.Text = "_tabNumberColumn";
            this._tabNumberColumn.Width = 47;
            // 
            // _hostNameColumn
            // 
            this._hostNameColumn.Text = "_hostNameColumn";
            this._hostNameColumn.Width = 193;
            // 
            // _commandBox
            // 
            this._commandBox.AcceptsReturn = true;
            this._commandBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._commandBox.Location = new System.Drawing.Point(0, 0);
            this._commandBox.Multiline = true;
            this._commandBox.Name = "_commandBox";
            this._commandBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._commandBox.Size = new System.Drawing.Size(341, 145);
            this._commandBox.TabIndex = 1;
            this._commandBox.WordWrap = false;
            this._commandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._commandBox_KeyDown);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(12, 151);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(104, 23);
            this._okButton.TabIndex = 2;
            this._okButton.Text = "_okButton";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(122, 151);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(104, 23);
            this._cancelButton.TabIndex = 3;
            this._cancelButton.Text = "_cancelButton";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _repeatCountLabel
            // 
            this._repeatCountLabel.AutoSize = true;
            this._repeatCountLabel.Location = new System.Drawing.Point(12, 185);
            this._repeatCountLabel.Name = "_repeatCountLabel";
            this._repeatCountLabel.Size = new System.Drawing.Size(98, 12);
            this._repeatCountLabel.TabIndex = 0;
            this._repeatCountLabel.Text = "_repeatCountLabel";
            this._repeatCountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _repeatCountBox
            // 
            this._repeatCountBox.Location = new System.Drawing.Point(274, 183);
            this._repeatCountBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this._repeatCountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._repeatCountBox.Name = "_repeatCountBox";
            this._repeatCountBox.Size = new System.Drawing.Size(62, 19);
            this._repeatCountBox.TabIndex = 5;
            this._repeatCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._repeatCountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._repeatCountBox.ValueChanged += new System.EventHandler(this._repeatCountBox_ValueChanged);
            // 
            // _repeatIntervalBox
            // 
            this._repeatIntervalBox.Location = new System.Drawing.Point(274, 212);
            this._repeatIntervalBox.Maximum = new decimal(new int[] {
            999000,
            0,
            0,
            0});
            this._repeatIntervalBox.Name = "_repeatIntervalBox";
            this._repeatIntervalBox.Size = new System.Drawing.Size(62, 19);
            this._repeatIntervalBox.TabIndex = 6;
            this._repeatIntervalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._repeatIntervalBox.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // _repeatIntervalLabel
            // 
            this._repeatIntervalLabel.AutoSize = true;
            this._repeatIntervalLabel.Location = new System.Drawing.Point(12, 214);
            this._repeatIntervalLabel.Name = "_repeatIntervalLabel";
            this._repeatIntervalLabel.Size = new System.Drawing.Size(106, 12);
            this._repeatIntervalLabel.TabIndex = 0;
            this._repeatIntervalLabel.Text = "_repeatIntervalLabel";
            this._repeatIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _logButton
            // 
            this._logButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._logButton.Location = new System.Drawing.Point(232, 266);
            this._logButton.Name = "_logButton";
            this._logButton.Size = new System.Drawing.Size(104, 23);
            this._logButton.TabIndex = 12;
            this._logButton.Text = "_logButton";
            this._logButton.UseVisualStyleBackColor = true;
            this._logButton.Click += new System.EventHandler(this._logButton_Click);
            // 
            // _logBox
            // 
            this._logBox.AcceptsReturn = true;
            this._logBox.Dock = System.Windows.Forms.DockStyle.Right;
            this._logBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._logBox.Location = new System.Drawing.Point(346, 0);
            this._logBox.Multiline = true;
            this._logBox.Name = "_logBox";
            this._logBox.ReadOnly = true;
            this._logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._logBox.Size = new System.Drawing.Size(258, 427);
            this._logBox.TabIndex = 15;
            this._logBox.WordWrap = false;
            this._logBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._logBox_KeyDown);
            // 
            // _refreshListButton
            // 
            this._refreshListButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._refreshListButton.Location = new System.Drawing.Point(122, 266);
            this._refreshListButton.Name = "_refreshListButton";
            this._refreshListButton.Size = new System.Drawing.Size(104, 23);
            this._refreshListButton.TabIndex = 11;
            this._refreshListButton.Text = "_refreshListButton";
            this._refreshListButton.UseVisualStyleBackColor = true;
            this._refreshListButton.Click += new System.EventHandler(this._refreshListButton_Click);
            // 
            // _commandClearButton
            // 
            this._commandClearButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._commandClearButton.Location = new System.Drawing.Point(232, 151);
            this._commandClearButton.Name = "_commandClearButton";
            this._commandClearButton.Size = new System.Drawing.Size(104, 23);
            this._commandClearButton.TabIndex = 4;
            this._commandClearButton.Text = "_commandClearbutton";
            this._commandClearButton.UseVisualStyleBackColor = true;
            this._commandClearButton.Click += new System.EventHandler(this._commandClearButton_Click);
            // 
            // _listAllSelectButton
            // 
            this._listAllSelectButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._listAllSelectButton.Location = new System.Drawing.Point(12, 266);
            this._listAllSelectButton.Name = "_listAllSelectButton";
            this._listAllSelectButton.Size = new System.Drawing.Size(104, 23);
            this._listAllSelectButton.TabIndex = 10;
            this._listAllSelectButton.Text = "_listAllSelectButton";
            this._listAllSelectButton.UseVisualStyleBackColor = true;
            this._listAllSelectButton.Click += new System.EventHandler(this._listAllSelectButton_Click);
            // 
            // _alwaysOnTopCheck
            // 
            this._alwaysOnTopCheck.AutoSize = true;
            this._alwaysOnTopCheck.Location = new System.Drawing.Point(12, 295);
            this._alwaysOnTopCheck.Name = "_alwaysOnTopCheck";
            this._alwaysOnTopCheck.Size = new System.Drawing.Size(128, 16);
            this._alwaysOnTopCheck.TabIndex = 13;
            this._alwaysOnTopCheck.Text = "_alwaysOnTopCheck";
            this._alwaysOnTopCheck.UseVisualStyleBackColor = true;
            this._alwaysOnTopCheck.CheckedChanged += new System.EventHandler(this._alwaysOnTopCheck_CheckedChanged);
            // 
            // _notSendNewLineCheck
            // 
            this._notSendNewLineCheck.AutoSize = true;
            this._notSendNewLineCheck.Location = new System.Drawing.Point(173, 295);
            this._notSendNewLineCheck.Name = "_notSendNewLineCheck";
            this._notSendNewLineCheck.Size = new System.Drawing.Size(144, 16);
            this._notSendNewLineCheck.TabIndex = 14;
            this._notSendNewLineCheck.Text = "_notSendNewLineCheck";
            this._notSendNewLineCheck.UseVisualStyleBackColor = true;
            // 
            // _clearBufferButton
            // 
            this._clearBufferButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._clearBufferButton.Location = new System.Drawing.Point(12, 237);
            this._clearBufferButton.Name = "_clearBufferButton";
            this._clearBufferButton.Size = new System.Drawing.Size(104, 23);
            this._clearBufferButton.TabIndex = 7;
            this._clearBufferButton.Text = "_clearBufferButton";
            this._clearBufferButton.UseVisualStyleBackColor = true;
            this._clearBufferButton.Click += new System.EventHandler(this._clearBufferButton_Click);
            // 
            // _sendNewLineButton
            // 
            this._sendNewLineButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._sendNewLineButton.Location = new System.Drawing.Point(122, 237);
            this._sendNewLineButton.Name = "_sendNewLineButton";
            this._sendNewLineButton.Size = new System.Drawing.Size(104, 23);
            this._sendNewLineButton.TabIndex = 8;
            this._sendNewLineButton.Text = "_sendNewLineButton";
            this._sendNewLineButton.UseVisualStyleBackColor = true;
            this._sendNewLineButton.Click += new System.EventHandler(this._sendNewLineButton_Click);
            // 
            // _sendCtrlCButton
            // 
            this._sendCtrlCButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._sendCtrlCButton.Location = new System.Drawing.Point(232, 237);
            this._sendCtrlCButton.Name = "_sendCtrlCButton";
            this._sendCtrlCButton.Size = new System.Drawing.Size(104, 23);
            this._sendCtrlCButton.TabIndex = 9;
            this._sendCtrlCButton.Text = "_sendCtrlCButton";
            this._sendCtrlCButton.UseVisualStyleBackColor = true;
            this._sendCtrlCButton.Click += new System.EventHandler(this._sendCtrlCButton_Click);
            // 
            // BroadcastCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(604, 427);
            this.Controls.Add(this._sendCtrlCButton);
            this.Controls.Add(this._sendNewLineButton);
            this.Controls.Add(this._clearBufferButton);
            this.Controls.Add(this._notSendNewLineCheck);
            this.Controls.Add(this._alwaysOnTopCheck);
            this.Controls.Add(this._listAllSelectButton);
            this.Controls.Add(this._commandClearButton);
            this.Controls.Add(this._refreshListButton);
            this.Controls.Add(this._logBox);
            this.Controls.Add(this._logButton);
            this.Controls.Add(this._repeatIntervalBox);
            this.Controls.Add(this._repeatIntervalLabel);
            this.Controls.Add(this._repeatCountBox);
            this.Controls.Add(this._repeatCountLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._sessionListView);
            this.Controls.Add(this._commandBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BroadcastCommandForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BroadcastCommandForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this._repeatCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._repeatIntervalBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _sessionListView;
        private System.Windows.Forms.ColumnHeader _tabNumberColumn;
        private System.Windows.Forms.ColumnHeader _hostNameColumn;
        private System.Windows.Forms.TextBox _commandBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _repeatCountLabel;
        private System.Windows.Forms.NumericUpDown _repeatCountBox;
        private System.Windows.Forms.NumericUpDown _repeatIntervalBox;
        private System.Windows.Forms.Label _repeatIntervalLabel;
        private System.Windows.Forms.Button _logButton;
        private System.Windows.Forms.TextBox _logBox;
        private System.Windows.Forms.Button _refreshListButton;
        private System.Windows.Forms.Button _commandClearButton;
        private System.Windows.Forms.Button _listAllSelectButton;
        private System.Windows.Forms.CheckBox _alwaysOnTopCheck;
        private System.Windows.Forms.CheckBox _notSendNewLineCheck;
        private System.Windows.Forms.Button _clearBufferButton;
        private System.Windows.Forms.Button _sendNewLineButton;
        private System.Windows.Forms.Button _sendCtrlCButton;
    }

}