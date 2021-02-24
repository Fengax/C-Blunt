using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Position
    {
        public int index;
        public int line;
        public int column;
        public string fileName;
        public string fileText;
        public Position(int index_, int line_, int column_, string fileName_, string fileText_)
        {
            index = index_;
            line = line_;
            column = column_;
            fileName = fileName_;
            fileText = fileText_;
        }

        public void move(char currentChar = '\0')
        {
            index += 1;
            column += 1;

            if (currentChar == '\n')
            {
                line += 1;
                column = 0;
            }
        }

        public Position make_class()
        {
            Position this_position = new Position(index, line, column, fileName, fileText);
            return this_position;
        }
    }
}
