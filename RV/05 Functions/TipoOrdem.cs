using System.Collections.Generic;

namespace RV
{
    public class TipoOrdem
    {
        public Dictionary<char, string> DicionarioOpcoes()
        {
            int i = 1;
            int mes;
            string tipo;

            Dictionary<char, string> dic = new();
            for (char letter = 'A'; letter <= 'X'; letter++)
            {
                mes = (i > 12) ? i - 12 : i;
                tipo = (i > 12) ? "Put" : "Call";
                dic.Add(letter, mes + "," + tipo);
                i++;
            };

            return dic;
        }
    }
}
