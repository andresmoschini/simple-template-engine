using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public struct Cursor
    {
        public readonly string Text;
        public readonly int CurrentPos;
        public int Lenght { get { return Text.Length; } }
        public bool AtEnd { get { return CurrentPos == Lenght; } }
        
        public Cursor(string text)
        {
            Text = text;
            CurrentPos = 0;
        }

        private Cursor(string text, int currentPos)
        {
            Text = text;
            CurrentPos = currentPos > text.Length ? text.Length : currentPos;
        }

        public Cursor Advance(int value = 1)
        {
            return new Cursor(Text, CurrentPos + value);
        }

        public Cursor AdvanceToEnd()
        {
            return new Cursor(Text, Lenght);
        }

        public string GetDifference(Cursor other)
        {
            if (Text != other.Text)
            {
                throw new InvalidOperationException("Other cursor should refer to the same Text");
            }
            var startPos = Math.Min(CurrentPos, other.CurrentPos);
            var endPos = Math.Max(CurrentPos, other.CurrentPos);
            return Text.Substring(startPos, endPos - startPos);
        }

        public Cursor Seek(string text)
        {
            var pos = Text.IndexOf(text, CurrentPos);
            return new Cursor(Text, pos);
        }

        public bool Match(string text)
        {
            if (text.Length + CurrentPos > Text.Length)
            {
                return false;
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != Text[CurrentPos + i])
                {
                    return false;
                }
            }
            return true;
        }

        public Cursor SeekAny(char[] anyOf)
        {
            var pos = Text.IndexOfAny(anyOf, CurrentPos);
            if (pos == Lenght || pos < 0)
            {
                return AdvanceToEnd();
            }
            else
            {
                return new Cursor(Text, pos);
            }
        }

        public Cursor SeekAny(IEnumerable<string> anyOf, out string found)
        {
            var anyOfSorted = anyOf.OrderByDescending(x => x.Length).ToArray();
            var firstChars = anyOfSorted.Select(x => x[0]).Distinct().ToArray();
            var newCursor = SeekAny(firstChars);
            found = null;
            while (!newCursor.AtEnd)
            {
                found = anyOfSorted.FirstOrDefault(x => newCursor.Match(x));
                if (found != null)
                {
                    return newCursor;
                }
                newCursor = newCursor.Advance().SeekAny(firstChars);
            }
            return newCursor;
        }

        public override string ToString()
        {
            const int sampleLenght = 30;
            
            var sampleFinish = Math.Min(Lenght, CurrentPos + sampleLenght);

            return string.Format("{0}{1}{2}",
                CurrentPos > 0 ? "..." : string.Empty,
                Text.Substring(CurrentPos, sampleFinish - CurrentPos),
                sampleFinish < Lenght ? "..." : string.Empty);
        }
    }
}
