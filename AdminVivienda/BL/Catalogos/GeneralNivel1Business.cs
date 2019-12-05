using AdminVivienda.DAL.Catalogos;
using AdminVivienda.Models.Catalogos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminVivienda.BL.Catalogos
{
    public class GeneralNivel1Business
    {
        private GeneralManageNivel1 _manage;
        public GeneralNivel1Business(string idName, string columnName, string tabla)
        {
            _manage = new GeneralManageNivel1(idName,columnName,tabla);
        }
        public List<Nivel1Model> Consultar(Nivel1Model modelo)
        {
            return _manage.Consultar(modelo);
        }

    }
}