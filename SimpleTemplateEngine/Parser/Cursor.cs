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
        public readonly int Length;
        public bool AtEnd { get { return CurrentPos >= Length; } }
        
        public Cursor(string text)
        {
            Text = text;
            CurrentPos = 0;
            Length = text.Length;
        }

        private Cursor(string text, int currentPos, int lenght)
        {
            Text = text;
            CurrentPos = currentPos > text.Length ? text.Length : currentPos;
            Length = lenght;
        }

        public Cursor Truncate()
        {
            return new Cursor(Text, CurrentPos, CurrentPos);
        }

        public Cursor Advance(int value = 1)
        {
            return new Cursor(Text, CurrentPos + value, Length);
        }

        public Cursor AdvanceTo(int value)
        {
            return new Cursor(Text, value < Length ? value : Length, Length);
        }

        public Cursor AdvanceToEnd()
        {
            return new Cursor(Text, Length, Length);
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
            if (pos < 0)
            {
                //TODO: take it into account what happen when text is not present
                return AdvanceToEnd();
            }
            else
            {
                return new Cursor(Text, pos, Length);
            }
        }

        public bool Match(string text)
        {
            if (text.Length + CurrentPos > Length)
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
            if (pos >= Length || pos < 0)
            {
                return AdvanceToEnd();
            }
            else
            {
                return new Cursor(Text, pos, Length);
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
            
            var sampleFinish = Math.Min(Length, CurrentPos + sampleLenght);

            return string.Format("{0}{1}{2}",
                CurrentPos > 0 ? "..." : string.Empty,
                Text.Substring(CurrentPos, sampleFinish - CurrentPos),
                sampleFinish < Length ? "..." : string.Empty);
        }

    }
}
