/* Generated By:CSharpCC: Do not edit this line. TokenMgrError.cs Version 3.0 */
namespace org.mariuszgromada.math.mxparser.syntaxchecker {


public class TokenMgrError : System.SystemException
{
   /*
    * Ordinals for various reasons why an Exceptions of this type can be thrown.
    */

   /**
    * Lexical error occured.
    */
   internal static readonly int LexicalError = 0;

   /**
    * An attempt wass made to create a second instance of a static token manager.
    */
   internal static readonly int StaticLexerError = 1;

   /**
    * Tried to change to an invalid lexical state.
    */
   internal static readonly int InvalidLexicalState = 2;

   /**
    * Detected (and bailed out of) an infinite loop in the token manager.
    */
   internal static readonly int LoopDetected = 3;

   /**
    * Indicates the reason why the exception is thrown. It will have
    * one of the above 4 values.
    */
   int errorCode;

   /**
    * Replaces unprintable characters by their espaced (or unicode escaped)
    * equivalents in the given string
    */
   protected static string AddEscapes(string str) {
      System.Text.StringBuilder retval = new System.Text.StringBuilder();
      char ch;
      for (int i = 0; i < str.Length; i++) {
        switch (str[i]) {
           case '\0' :
              continue;
           case '\b':
              retval.Append("\\b");
              continue;
           case '\t':
              retval.Append("\\t");
              continue;
           case '\n':
              retval.Append("\\n");
              continue;
           case '\f':
              retval.Append("\\f");
              continue;
           case '\r':
              retval.Append("\\r");
              continue;
           case '\"':
              retval.Append("\\\"");
              continue;
           case '\'':
              retval.Append("\\\'");
              continue;
           case '\\':
              retval.Append("\\\\");
              continue;
           default:
              if ((ch = str[i]) < 0x20 || ch > 0x7e) {
                 string s = "0000" + System.Convert.ToString((int)ch, 16);
                 retval.Append("\\u" + s.Substring(s.Length - 4, s.Length - (s.Length - 4)));
              } else {
                 retval.Append(ch);
              }
              continue;
        }
      }
      return retval.ToString();
   }

   /**
    * Returns a detailed message for the Exception when it is thrown by the
    * token manager to indicate a lexical error.
    * Parameters : 
    *    EOFSeen     : indicates if EOF caused the lexicl error
    *    curLexState : lexical state in which this error occured
    *    errorLine   : line number when the error occured
    *    errorColumn : column number when the error occured
    *    errorAfter  : prefix that was seen before this error occured
    *    curchar     : the offending character
    * Note: You can customize the lexical error message by modifying this method.
    */
   protected static string GetLexicalError(bool EOFSeen, int lexState, int errorLine, int errorColumn, string errorAfter, char curChar) {
      return("Lexical error at line " +
           errorLine + ", column " +
           errorColumn + ".  Encountered: " +
           (EOFSeen ? "<EOF> " : ("\"" + AddEscapes(curChar.ToString()) + "\"") + " (" + (int)curChar + "), ") +
           "after : \"" + AddEscapes(errorAfter) + "\"");
   }

   /**
    * You can also modify the body of this method to customize your error messages.
    * For example, cases like LOOP_DETECTED and INVALID_LEXICAL_STATE are not
    * of end-users concern, so you can return something like : 
    *
    *     "Internal Error : Please file a bug report .... "
    *
    * from this method for such cases in the release version of your parser.
    */
   public override string Message {
      get { return base.Message; }
   }

   /*
    * Constructors of various flavors follow.
    */

   public TokenMgrError() {
   }

   public TokenMgrError(string message, int reason) :
      base(message) {
      errorCode = reason;
   }

   public TokenMgrError(bool EOFSeen, int lexState, int errorLine, int errorColumn, string errorAfter, char curChar, int reason) :
      this(GetLexicalError(EOFSeen, lexState, errorLine, errorColumn, errorAfter, curChar), reason) {
   }
}
}
