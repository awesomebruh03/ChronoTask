   M S B A M L   `   `   `  ����E  AChronoTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChronoTask
ChronoTask  5   	       ChronoTask.Start   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChronoTask     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � AllowsTransparency$
 True��6R   
������  � Title$ Start��5   	   $	��450��6   $	��800��6$   .��5	      ��  �� CornerRadius$ 40��6   ��5
   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #00FFFF��6    � Offset$ 0Q�6/   � 5      $ #000033��6   $ 1Q�6/   5      ._�5   
   � 	 � ColumnDefinitions	 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5        
 ��Name$
 chronoLabel��5      $��Chorono��6)   
�������$��60(�6N   $
��Bold"�6\   $��	0,170,0,0q�6n   z�5      T� 5       T� X$
 -300Q�6)   5      �� 5      -   5        $
 	taskLabel��5      $��Task 2.0��6'   
�������$��60(�6M   $
��Bold"�6[   $��	0 170,0,0q�6m   $��1��6�   z�5      T� 5      $	 300Q�6)   5      5      5        � Triggers 5!      :� 5"   
    :� RoutedEvent$ Window.Loaded��6   .[�5#      �� .��5$      �� .��5%      W�  �� 
TargetName$ chronoLabel��6&    �� TargetProperty$4 .(Label.RenderTransform).(TranslateTransform.X)�6J    W� From -3006�   	 W� To 1426�    g� Duration$ 0:0:1D�6�   W� 5&      $ 	taskLabel��6&   $4 .(Label.RenderTransform).(TranslateTransform.X)�6H    3006�    06�   $ 0:0:1D�6�   5'      5(      5)      5+      