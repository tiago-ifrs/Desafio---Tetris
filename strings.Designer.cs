//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desafio___Tetris {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal strings() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Desafio___Tetris.strings", typeof(strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Game Over.
        /// </summary>
        internal static string Form1_Tetris_Game_Over {
            get {
                return ResourceManager.GetString("Form1_Tetris_Game_Over", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Tempo de Jogo.
        /// </summary>
        internal static string FormLabels_FormLabels_Elapsed_Time {
            get {
                return ResourceManager.GetString("FormLabels_FormLabels_Elapsed_Time", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Nível.
        /// </summary>
        internal static string FormLabels_FormLabels_Level {
            get {
                return ResourceManager.GetString("FormLabels_FormLabels_Level", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Peças.
        /// </summary>
        internal static string FormLabels_FormLabels_Pieces {
            get {
                return ResourceManager.GetString("FormLabels_FormLabels_Pieces", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Score.
        /// </summary>
        internal static string FormLabels_FormLabels_Score {
            get {
                return ResourceManager.GetString("FormLabels_FormLabels_Score", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Velocidade.
        /// </summary>
        internal static string FormLabels_FormLabels_Speed {
            get {
                return ResourceManager.GetString("FormLabels_FormLabels_Speed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} (linhas/s).
        /// </summary>
        internal static string ScoreView_Speed__0___lines_s_ {
            get {
                return ResourceManager.GetString("ScoreView_Speed__0___lines_s_", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a CREATE TABLE IF NOT EXISTS &quot;pontuacao&quot; (
        ///	&quot;id&quot;	INTEGER NOT NULL,
        ///	&quot;nome&quot;	TEXT NOT NULL,
        ///	&quot;score&quot;	INTEGER NOT NULL,
        ///	&quot;nivel&quot;	INTEGER NOT NULL,
        ///	&quot;tempo_jogo&quot;	TEXT NOT NULL,
        ///	&quot;qtd_pecas&quot;	INTEGER NOT NULL,
        ///	&quot;data_score&quot;	TEXT NOT NULL,
        ///	&quot;tabuleiro&quot;	BLOB NOT NULL,
        ///	PRIMARY KEY(&quot;id&quot; AUTOINCREMENT)
        ///);.
        /// </summary>
        internal static string SQLite_Create {
            get {
                return ResourceManager.GetString("SQLite_Create", resourceCulture);
            }
        }
    }
}
