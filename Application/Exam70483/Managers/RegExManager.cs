using System.Web;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Exam70483Library.Managers
{
    public class RegExManager
    {
        #region "Campos"
        private        string _tagSearch;
        private        string _textSearch;
        private        string _textContent;
        private        string _textContentRaw;
        private static string _pattern;
        #endregion

        #region "Propiedades"
        public static string RegEx
        { 
            get
            {
                return _pattern;
            }
        }
        #endregion

        #region "Constructor"
        public RegExManager
            (
              string p_tagSearch
            , string p_textSearch
            , string p_textContentRaw
            )
        {
            this._tagSearch      = p_tagSearch;
            this._textSearch     = p_textSearch;
            this._textContentRaw = p_textContentRaw;
        }
        #endregion|

        #region "Metodos"
        public string GetMaches()
        {
            //
            Regex rx;
            //
            MatchCollection matchCollection;
            //
            _pattern                        = string.Format(@"(<{0}.*>)(.*{1}.*)(<\/{0}>)",_tagSearch,_textSearch);
            //
            //-----------------------------------------
            // LOG
            //-----------------------------------------
#if DEBUG    
            //
            LogModel.Log(string.Format(@"REGEX_TEXT_TO_EVAL : {0}", _textContent));
            //
            LogModel.Log(string.Format(@"REGEX_PATTERN      : {0}", _pattern));
#endif
            //
            rx                             = new Regex(_pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //
            matchCollection                = rx.Matches(_textContentRaw);
            //
            _textContent                   = _textContentRaw;            
            //
            foreach (Match matchEntry in matchCollection)
            {
#if DEBUG
                //
                LogModel.Log(
                                    string.Format("REGEX_XML. Match_Index ='{0}', Match_Value ='{1}'"
                                                                , matchEntry.Index
                                                                , matchEntry.Value)
                             );
#endif
                    //
                    _textContent = _textContent.Replace(matchEntry.Value, string.Format(@"[{0}]", matchEntry.Value));
            }
            //---------------------------------------------------------------------------------------
            // CORREGIR LINE FEEDS    
            //---------------------------------------------------------------------------------------
            string _lineBreakPattern                 = @"(\r\n)";
            //
            rx                                       = new Regex(_lineBreakPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //
            MatchCollection matchCollectionLineBreak = rx.Matches(_textContent);
            //
            foreach (Match matchEntryLineBreak in matchCollectionLineBreak)
            {
                _textContent = _textContent.Replace(matchEntryLineBreak.Value, string.Format(@"|", matchEntryLineBreak.Value));
            }
            //---------------------------------------------------------------------------------------
            // CORREGIR TABS
            //---------------------------------------------------------------------------------------
            string _tabBreakPattern             = @"[ \t]";
            //
            rx                                  = new Regex(_tabBreakPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //
            MatchCollection matchCollectiontabs = rx.Matches(_textContent);
            //
            foreach (Match matchEntryTab in matchCollectiontabs)
            {
                _textContent = _textContent.Replace(matchEntryTab.Value, string.Format(@"■", matchEntryTab.Value));
            }
            //-------------------------------------------------------------------------------------------
            // CONVERTGIR A CARACTERES LEGIBLES DE HTML
            //-------------------------------------------------------------------------------------------
            //    
            _textContent          = HttpUtility.HtmlEncode(_textContent);
            _textContent          = _textContent.Replace(@"|", @"<br/>");
            _textContent          = _textContent.Replace(@"■", @"&nbsp;");
            _textContent          = _textContent.Replace(@"[", @"<mark>");
            _textContent          = _textContent.Replace(@"]", @"</mark>");
            //
            string status         = string.Format(@"{0}|{1}|{2}"
                                        , matchCollection.Count.ToString()
                                        , _textContent
                                        , _pattern);
            //
            return status;
        }
#endregion
    }
}
