   M S B A M L   `   `   `  ����  Tablets"    Poda.Tablets.UI.TabletDialog   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Tablet��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�67   .��5      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��question��5      $��1��6    .��60   Enter tablet info:6D   �� 5   
   -   5        $��tabletModel��5      $��0,5,0,0q�6%   $��1��66   $��1��6F   $	��250��6S   .��6b   Pro 116j   �� 5   
   -   5        $��tabletDisplay��5      $��0,5,0,0q�6(   $��1��69   $��2��6I   .@�5      ��  �� 
IsSelected$
 True��6   .��6-   AMOLED65   �� 5      .��6   Retina6#   5      �� 5   
   -   5        $��producer��5      $��0,5,0,0q�6#   $��1��64   $��3��6D   �� 5   
   -   5        $��tabletPrice��5      $��0,5,0,0q�6%   $��1��66   $��4��6F   $	��250��6S   .��6�   25006�   � 5   
   $��1��6   $��5��6$   $��2��61   $��Right=�6E   $��0,15,0,0q�6a   .+�5      �� -   5        $��btnDialogOk��5   &    �� 	IsDefault$
 True��6   $��60��6S   $��0,0,10,0q�6a   .��6s   _Apply6{   �� 5       �� IsCancel$
 True��6   $��60��6%   .��63   	_Cancel6<   5       5!      5"      