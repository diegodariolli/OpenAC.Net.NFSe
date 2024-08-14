// ***********************************************************************
// Assembly         : OpenAC.Net.NFSe
// Author           : Rafael Dias
// Created          : 08-14-2024
//
// Last Modified By : Rafael Dias
// Last Modified On : 08-14-2024
// ***********************************************************************
// <copyright file="ProviderFiorilli.cs" company="OpenAC .Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2014 - 2023 Projeto OpenAC .Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using OpenAC.Net.NFSe.Configuracao;

namespace OpenAC.Net.NFSe.Providers;

internal sealed class ProviderPronim : ProviderABRASF
{
    #region Constructors

    public ProviderPronim(ConfigNFSe config, OpenMunicipioNFSe municipio) : base(config, municipio)
    {
        Name = "Pronim";
    }

    #endregion Constructors

    #region Methods

    protected override string GerarCabecalho()
    {
        return "<tem:cabecalho versao=\"1.00\">" +
               "<tem:versaoDados>1.00</tem:versaoDados>" +
               "</tem:cabecalho>";
    }

    protected override IServiceClient GetClient(TipoUrl tipo) => new PronimServiceClient(this, tipo, null);

    protected override void ValidarSchema(RetornoWebservice retorno, string schema)
    {
        base.ValidarSchema(retorno, schema);
        if(retorno.Erros.Count > 0) return;

        retorno.XmlEnvio = retorno.XmlEnvio.Replace(" xmlns=\"http://www.abrasf.org.br/nfse.xsd\"", "");
    }

    #endregion Methods
}