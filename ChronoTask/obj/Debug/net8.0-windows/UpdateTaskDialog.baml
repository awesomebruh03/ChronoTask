   M S B A M L   `   `   `  ����E  AChronoTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChronoTask
ChronoTask  5   	   !    ChronoTask.UpdateTaskDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:ChronoTask     5   	     � Title$  Add Task��5   
   $	��450��6   $	��420��6(   .��5      �� ��5   
   �� 5	       �� 
StartPoint$	 0 0&�6"    �� EndPoint$	 1 1&�63   .��5
      �  � Color$ #00FFFF��6    � Offset$ 1Q�6/   � 5      $ #000033��6   $ 0Q�6/   5      ._�5   
   � .+�5      �� .+�5      �� -   5         ��Name$ TaskNameTextBox��5      $��10q�63   
������ 6?   �� 5      -   5        $ TaskDescriptionTextBox��5      $��10q�6:   
������ 6F   �� 5      $��Start Time:��6   $��10q�6/   
�������6;   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ TaskStartDatePicker��5      $��10q�6:   
������ 6F      ChronoTask.TimePicker  5      -   5          Name$ TaskStartTimePicker��5   #   $��	77 10 0 0q�6@   �� 5      $��	End Time:��6   $��10q�6-   
�������69     5      -   5        $ TaskEndDatePicker��5      $��10q�68   
������ 6D     5      -   5        $ TaskEndTimePicker��5   #   $��	77 10 0 0q�6>   �� 5      -   5        $
��Save��5      $��10q�6A      ButtonStyle#��[  6M   5      5      5      5      