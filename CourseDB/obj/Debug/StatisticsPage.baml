   M S B A M L   `   `   `  ����C  ?CourseDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CourseDBCourseDB  5          CourseDB.StatisticsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:CourseDB     5      R NOxyPlot.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5	        N� Title$  
Statistics��5
      .��5      �  � 	Resources 5   
    �� 
TargetType �� Property �� Value��%[   '��       �� 5      " ��6   .�5      ��  � ��$ Center=�6?   6P   5      5       � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��8* �6   6*   .+�5   
   �� $��16(�6   $��Consolas)�6   $����Статистика по картинам выбранного художника (картины с неизвестным годом написания не учитываются)��64   $��Stretch=�6�   $��Stretch=�6�   $��2��6�   
���   �
�������6    OxyPlot.Wpf.PlotView  5   
   -   5          Name$
 Plot��5      $��1��6A      Model 6%   �� *	StatModel+5      � 5   
   $��1��6   $��1��6   .+�5      �� -   5        	 ��Name$	 ChosenArtist��5      
 �� DisplayMemberPath$
 	full_name��6n    �� SelectedValuePath$ id��6�   $
��Left=�6�   $��	10,45,0,0q�6�   $	��Top=�6�   $	��105��6  ��6-   ��    artistViewSource �� Source# [   �� SelectedValue 6�   �� *	Artist_Id+6  �� 5      $��Художник��6   $
��Left=�6'   $��	10,15,0,0q�6B   $	��Top=�6U   $	��105��6m   �� 5       -   5        $$��Сохранить изобр.��5       $
��Left=�60   $��	10,88,0,0q�6K   $	��Top=�6^   $	��105��6v   $��28��6�   6�   �� 5!      -   5        $��Сохранить в PDF��5!      $
��Left=�6/   $��
10,121,0,0q�6J   $	��Top=�6^   $	��105��6v   $��28��6�   6�   5"      5#      5$      