namespace MultiChoiceService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MultiChoiceServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MultiChoiceServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // MultiChoiceServiceProcessInstaller
            // 
            this.MultiChoiceServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MultiChoiceServiceProcessInstaller.Password = null;
            this.MultiChoiceServiceProcessInstaller.Username = null;
            // 
            // MultiChoiceServiceInstaller
            // 
            this.MultiChoiceServiceInstaller.ServiceName = "Service";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MultiChoiceServiceProcessInstaller,
            this.MultiChoiceServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller MultiChoiceServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller MultiChoiceServiceInstaller;
    }
}