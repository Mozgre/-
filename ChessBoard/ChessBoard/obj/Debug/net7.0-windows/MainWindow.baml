   M S B A M L   `   `   `  ����E  AChessBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChessBoard
ChessBoard  5   	   9!clr-namespace:ChessBoard.ControlsChessBoard.Controls  5   	       ChessBoard.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChessBoard     5   	   6controls!clr-namespace:ChessBoard.Controls     5   	     � Title$  Шахматы��5	   	    � SizeToContent$ WidthAndHeight=�6    � 
ResizeMode$ CanMinimize=�68    J� SnapsToDevicePixels$
 True��5   	    � 	Resources 5      #   ChessBoard.CellColorConverter   CellColorConverter��%   &	          5   
   6#   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $
��-5,0q�6>   .+�5      �� $��Новая игра��6   $��5q�6*   $
��10,5q�65   ��6D   �� *NewGameCommand+�� 5      $��Очистка поля��6   $��5q�6,   $
��10,5q�67   ��6F   �� *ClearCommand+5      �� 5   
   $��2��6   $��21��6D   ��6$   �� *	Numbers+��5       �� 5!      .R�5"      � $��60��6   .+�5#      ��  �� Padding$	 5,0q�6$   $��Center=�6C   	 �� TextAlignment$	 Center=�6^   $��16(�6u   ��62   �� 6u   5$      5%      5'      �� 5(   
   $��1��6   $��1��6$   $��21��6T   ��64   �� *	Letters+��5)      �� 5*      .R�5+      � $��60��6   .+�5,      �� $��Center=�65   $	 Center=�6P   $��16(�6g   ��6$   �� 6g   5-      5.      ��50      �� 51      .R�52      �� $ 
Horizontal=�6!   53      55      �� 56   
   $��2��6   $��1��6$   
 �� AlternationCount$
 64��6R   ��64   �� *Board+��57      �� 58      .R�59      �� $��60��6   $��60��6(   ��64   �� *DataContext.CellCommand+ �� RelativeSource ��  �� AncestorType
 Window��6�   �� ��5:      �� 5;       �� 
TargetType" ��6$   .�5<   "   ��  �� Property �@�OverridesDefaultStyle �� Value$
 True��6J   �� 5=   "    � ��
 �����6?   �� 5>   "    � �� 6@   Z� �� 5?   "    � ��$ 2q�6D   �� 5@   "    � �� 5A   &   �� 5B   *   .R�5C   .   �� #��z��65   ._�5D   2   �� #��z��69   #��z��6m   ._�5E   6   $   ChessBoard.Controls.ChessPiece     Piece 6J   �� *State+5F   3   5G   /   5H   +   5J   #    �� Triggers 5K   "   �� 5L   &    �� Binding 62   �� *!(ItemsControl.AlternationIndex)+ ��  ContentPresenter �� 	Converter# [   �� Value True6�   .a�5M   *   ��  � ��
 �   �6G   5N   '   �� 5O   &    62   �� *Active+ True6M   .a�5P   *   ��  � ��
 �  ��6H   5Q   '   5S      5U      5V      ��5X      �� 5Y      .R�5Z      A�  A� Columns$ 8��6"    A� Rows$ 8��6.   5[      5]      �� 5^   
   $��3��6   $��1��6$   $��21��6T   ��64   �� *	Letters+��5_      �� 5`      .R�5a      � $��60��6   .+�5b      �� $��Center=�65   $	 Center=�6P   $��16(�6g   ��6$   �� 6g   5c      5d      ��5f      �� 5g      .R�5h      �� $ 
Horizontal=�6!   5i      5k      �� 5l   
   $��2��6   $��2��6$   $��21��6T   ��64   �� *	Numbers+��5m      �� 5n      .R�5o      � $��60��6   .+�5p      �� $	 5,0q�6$   $��Center=�6C   $	 Center=�6^   $��16(�6u   ��62   �� 6u   5q      5r      5t      5u      5v      