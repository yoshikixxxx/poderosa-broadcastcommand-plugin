/*
 * Copyright 2015-2016 yoshikixxxx.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 */
using Poderosa.Commands;
using Poderosa.Forms;
using Poderosa.Plugins;
using Poderosa.Sessions;


/********* アセンブリ情報 *********/
[assembly: PluginDeclaration(typeof(Contrib.BroadcastCommand.BroadcastCommandPlugin))]
/**********************************/


namespace Contrib.BroadcastCommand {
    /********* プラグイン情報 *********/
    [PluginInfo(
        ID           = PLUGIN_ID,
        Version      = "1.2",
        Author       = "yoshikixxxx",
        Dependencies = "org.poderosa.core.window;org.poderosa.terminalsessions;org.poderosa.terminalemulator"
    )]
    /**********************************/




    /// <summary>
    /// BroadcastCommandプラグインメインクラス
    /// </summary>
    internal class BroadcastCommandPlugin : PluginBase {
        // メンバー変数
        public const string PLUGIN_ID = "contrib.yoshikixxxx.broadcastcommand";
        private static BroadcastCommandPlugin _instance;
        private static ICoreServices _coreServices;
        private static BroadcastCommandCommand _broadcastCommandCommand;
        private static Poderosa.StringResource _stringResource;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public override void InitializePlugin(IPoderosaWorld poderosa) {
            base.InitializePlugin(poderosa);
            _instance = this;

            // 文字列リソース読み込み
            _stringResource = new Poderosa.StringResource("Contrib.BroadcastCommand.strings", typeof(BroadcastCommandPlugin).Assembly);
            BroadcastCommandPlugin.Instance.PoderosaWorld.Culture.AddChangeListener(_stringResource);

            // メニュー登録
            IPluginManager pm = poderosa.PluginManager;
            _coreServices = (ICoreServices)poderosa.GetAdapter(typeof(ICoreServices));
            _broadcastCommandCommand = new BroadcastCommandCommand();
            _coreServices.CommandManager.Register(_broadcastCommandCommand);
            IExtensionPoint toolmenu = pm.FindExtensionPoint("org.poderosa.menu.tool");
            toolmenu.RegisterExtension(new PoderosaMenuGroupImpl(new IPoderosaMenu[] { new PoderosaMenuItemImpl(_broadcastCommandCommand, BroadcastCommandPlugin.Strings, "Menu.BroadcastCommand") }, false));
        }

        /// <summary>
        /// プラグイン終了
        /// </summary>
        public override void TerminatePlugin() {
            base.TerminatePlugin();
        }

        /// <summary>
        /// インスタンス
        /// </summary>
        public static BroadcastCommandPlugin Instance {
            get { return _instance; }
        }

        /// <summary>
        /// 文字列リソース
        /// </summary>
        public static Poderosa.StringResource Strings {
            get { return _stringResource; }
        }

        /// <summary>
        /// CommandManager
        /// </summary>
        public ICommandManager CommandManager {
            get { return _coreServices.CommandManager; }
        }

        /// <summary>
        /// WindowManager
        /// </summary>
        public IWindowManager WindowManager {
            get { return _coreServices.WindowManager; }
        }

        /// <summary>
        /// SessionManager
        /// </summary>
        public ISessionManager SessionManager {
            get { return _coreServices.SessionManager; }
        }
    }




    /// <summary>
    /// プラグイン実行クラス
    /// </summary>
    internal class BroadcastCommandCommand : GeneralCommandImpl {
        // メンバー変数
        BroadcastCommandForm Form = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BroadcastCommandCommand()
            : base(BroadcastCommandPlugin.PLUGIN_ID, BroadcastCommandPlugin.Strings, "Command.BroadcastCommand", BroadcastCommandPlugin.Instance.CommandManager.CommandCategories.Dialogs) {
            return;
        }

        /// <summary>
        /// プラグイン実行
        /// </summary>
        public override CommandResult InternalExecute(ICommandTarget target, params Poderosa.IAdaptable[] args) {
            // モードレス表示
            IPoderosaMainWindow window = CommandTargetUtil.AsWindow(target);
            Form = new BroadcastCommandForm(window);
            Form.Show();
            return CommandResult.Succeeded;

            /*
            // モーダル表示
            IPoderosaMainWindow window = CommandTargetUtil.AsWindow(target);
            BroadcastCommandForm Form = new BroadcastCommandForm(window);
            if (Form.ShowDialog(window.AsForm()) == DialogResult.OK) {
                return CommandResult.Succeeded;
            } else {
                return CommandResult.Cancelled;
            }
             */
        }

        /// <summary>
        /// 実行可能チェック(モードレス時の2重起動防止用)
        /// </summary>
        public override bool CanExecute(ICommandTarget target) {
            return (Form == null || Form.IsDisposed);
        }
    }
}
