using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;


namespace CarteraGeneral
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                FrmLogeo fAcceso = new FrmLogeo();
                if (fAcceso.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fAcceso.Close();
                    Application.Run(new FrmMenuGeneralRbf());
                }
            }
            catch (Exception)
            {
                
            }

        }
    }
}
