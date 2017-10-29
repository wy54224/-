﻿using System.ComponentModel;
using System.Drawing;

namespace ChineseChess
{
	public class ChessPos:INotifyPropertyChanged
	{
		private Point location;
		public Point Location
		{
			get => location;
			set
			{
				if(value != location)
				{
					location = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Location"));
				}
			}
		}

		private bool isLive = true;
		public bool Live
		{
			get => isLive;
			set
			{
				if(isLive != value)
				{
					isLive = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Live"));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
	public enum Player
	{
		Black, //黑子
		Red //红子
	}
	public enum ChessType
	{
		Rook1, //车1
		Knight1, //马1
		Elephant1, //象1
		Mandarin1, //士1
		King, //将
		Mandarin2, //士2
		Elephant2, //象2
		Knight2, //马2
		Rook2, //车2
		Cannon1, //炮1
		Cannon2, //炮2
		Pawn1, //卒1
		Pawn2, //卒2
		Pawn3, //卒3
		Pawn4, //卒4
		Pawn5, //卒5
		None //什么都不是
	}
	public class Model
	{
		private ChessPos [,]chess;
		public Model()
		{
			chess = new ChessPos[2, 16];
			for (int i = 0; i < 2; ++i)
				for (int j = 0; j < 16; ++j) chess[i, j] = new ChessPos();
			Reset();
		}

		public void Reset()
		{
			//位置初始化
			ChessPos tmpPos;
			//车->将位置初始化
			for (int i = (int)ChessType.Rook1; i <= (int)ChessType.Rook2; ++i)
			{
				tmpPos = chess[0, i];
				tmpPos.Location = new Point(i, 0);
				tmpPos.Live = true;
				tmpPos = chess[1, i];
				tmpPos.Location = new Point(i, 9);
				tmpPos.Live = true;
			}
			//炮位置初始化
			tmpPos = chess[0, (int)ChessType.Cannon1];
			tmpPos.Location = new Point(1, 2);
			tmpPos.Live = true;
			tmpPos = chess[0, (int)ChessType.Cannon2];
			tmpPos.Location = new Point(7, 2);
			tmpPos.Live = true;
			tmpPos = chess[1, (int)ChessType.Cannon1];
			tmpPos.Location = new Point(1, 7);
			tmpPos.Live = true;
			tmpPos = chess[1, (int)ChessType.Cannon2];
			tmpPos.Location = new Point(7, 7);
			tmpPos.Live = true;
			//卒位置初始化
			for (int i = (int)ChessType.Pawn1; i <= (int)ChessType.Pawn5; ++i)
			{
				tmpPos = chess[0, i];
				tmpPos.Location = new Point((i - (int)ChessType.Pawn1) << 1, 3);
				tmpPos.Live = true;
				tmpPos = chess[1, i];
				tmpPos.Location = new Point((i - (int)ChessType.Pawn1) << 1, 6);
				tmpPos.Live = true;
			}
		}

		public ChessPos this[Player player, ChessType chesstype]
		{
			get => chess[(int)player, (int)chesstype];
		}
	}
}
