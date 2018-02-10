using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[][] board = new string[8][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new string[8];
            board[i] = Console.ReadLine().Split(",".ToCharArray()).ToArray();
        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "END") break;

            string piece = command.First().ToString();
            int pieceRow = int.Parse(command.Substring(1, 1));
            int pieceCol = int.Parse(command.Substring(2, 1));
            int wantedRow = int.Parse(command.Substring(4, 1));
            int wantedCol = int.Parse(command.Substring(5, 1));

            if (!FigureExists(board, piece, pieceRow, pieceCol))
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (!IsMoveValid(piece, pieceRow, pieceCol, wantedRow, wantedCol))
            {
                Console.WriteLine("Invalid move!");
                continue;
            }
            
            if (!OutOfBoard(wantedRow, wantedCol))
            {
                Console.WriteLine("Move go out of board!");
                continue;
            }
            board[pieceRow][pieceCol] = "x";
            board[wantedRow][wantedCol] = piece;
        }
    }

    private static bool OutOfBoard(int row, int col)
    {
        bool validRow = row >= 0 && row <= 7;
        bool validCol = col >= 0 && col <= 7;

        return validRow && validCol;
    }

    private static bool FigureExists(string[][] board, string figureType, int row, int col)
    {
        return board[row][col] == figureType;
    }

    private static bool IsMoveValid(string piece, int pieceRow, int pieceCol, int wantedRow, int wantedCol)
    {
        switch (piece)
        {
            case "K": return ValidKingMove(pieceRow, pieceCol, wantedRow, wantedCol);
            case "R": return ValidStraightMove(pieceRow, pieceCol, wantedRow, wantedCol);
            case "B": return ValidDiagonalMove(pieceRow, pieceCol, wantedRow, wantedCol);
            case "Q":
                return 
                    ValidDiagonalMove(pieceRow, pieceCol, wantedRow, wantedCol) ||
                    ValidStraightMove(pieceRow, pieceCol, wantedRow, wantedCol);
            case "P": return ValidPawnMove(pieceRow, pieceCol, wantedRow, wantedCol);
                default: throw new Exception();
        }
    }

    private static bool ValidPawnMove(int startingRow, int startingCol, int targetRow, int targetCol)
    {
        bool validColumn = startingCol == targetCol;
        bool validRow = startingRow - 1 == targetRow;

        return validColumn && validRow;
    }

    private static bool ValidDiagonalMove(int pieceRow, int pieceCol, int wantedRow, int wantedCol)
    {
        return Math.Abs(pieceRow - wantedRow) == Math.Abs(pieceCol - wantedCol);
    }

    private static bool ValidStraightMove(int pieceRow, int pieceCol, int wantedRow, int wantedCol)
    {
        bool sameRow = pieceRow == wantedRow;
        bool sameCol = pieceCol == wantedCol;
        return sameRow || sameCol;
    }

    private static bool ValidKingMove(int pieceRow, int pieceCol, int wantedRow, int wantedCol)
    {
        bool rowMove = Math.Abs(pieceRow - wantedRow) == 1
                                    && Math.Abs(pieceCol - wantedCol) == 0;
        bool columnMove = Math.Abs(pieceCol - wantedCol) == 1
                          && Math.Abs(pieceRow - wantedRow) == 0;
        bool diagonalMove = Math.Abs(pieceCol - wantedCol) == 1
                            && Math.Abs(pieceRow - wantedRow) == 1;

        return rowMove || columnMove || diagonalMove;
    }
}
