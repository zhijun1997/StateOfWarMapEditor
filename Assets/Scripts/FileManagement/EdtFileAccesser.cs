using UnityEngine;
using UnityEngine.UI;
using RadiacUI;
using StateOfWarUtility;
using System.IO;

namespace MapEditor
{
    public sealed class EdtFileAccesser : FileAccesser
    {
        protected override string textRequest { get { return "EdtFileName"; } }
        protected override string notFound { get { return "$EdtNotFound$"; } }
        protected override string readHint { get { return "$EdtReadHint$"; } }
        
        protected override bool LoadNewFile()
        {
            if(!Edt.Validate(text.text)) return false;
            
            Global.inst.edt = new Edt(text.text);
            Global.inst.edtName = text.text;
            Global.inst.textAgent.Update(textRequest, Path.GetFileName(text.text));
            return true;
        }
    }
}
