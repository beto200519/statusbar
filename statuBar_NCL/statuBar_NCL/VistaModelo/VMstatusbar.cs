using System;
using System.Collections.Generic;
using System.Text;

namespace statuBar_NCL.VistaModelo
{
    public interface VMstatusbar
    {
        void OcultarStatusBar();
        void MostarStatusBar();
        void Traslucido();
        void Transparente();
        void CambiarColor();
    }
}
