using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesAI.Helpers;

public static class FontLoader
{
    private static PrivateFontCollection privateFonts =
        new PrivateFontCollection();

    public static Font CarregarFonte(string caminho, float tamanho, FontStyle estilo)
    {
        if (File.Exists(caminho))
        {
            privateFonts.AddFontFile(caminho);
            return new Font(privateFonts.Families[0], tamanho, estilo);
        }

        return SystemFonts.DefaultFont;
    }
}