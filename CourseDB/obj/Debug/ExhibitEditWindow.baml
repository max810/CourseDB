   M S B A M L   `   `   `  ����C  ?CourseDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CourseDBCourseDB  5   	        CourseDB.ExhibitEditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CourseDB     5   	   -   5          �Name$  UI��5   <    � Title$ ExhibitEditWindow��6	   $	��450��6#   $	��300��60   .��5	      � .+�5
   
   �� $��Экспонат��6   $��18(�6#   $��Center=�61   $��100,10,104.333,0q�6N   $	��Top=�6h   $��89��6�   �� 5   
   -   5         ��Name$ Painting_ComboBox��5   �   {�.  $
��Left=�6%   $��28��6�   $��
135,65,0,0q�6�    �� DisplayMemberPath$
 name��6�    �� SelectedValuePath$ id��6�   $	��Top=�6�   $	��120��6�   ��6@   ��    paintingViewSource �� Source# [  6�   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6d   $��
135,98,0,0q�6   $	��Top=�6�   $	��120��6�   $��29��6�      SelectedDate 6   ��  �� ElementName$ UI�� �� Path$&  CurrentExhibit.date_of_acquiring�6�   �� 5   
   $
��Left=�6Y   $��135,137,0,0q�6t   $	��Top=�6�   $	��120��6�   $��30��6�   	 d� 	IsChecked	 6   �� $ UI��$  CurrentExhibit.is_original�6�   �� 5   
   $��Картина��6   $
��Left=�6"   $��	37,65,0,0q�6=   $	��Top=�6P   $��28��6h   $��93��6t   �� 5   
   $��Дата приобр.��6   $
��Left=�6'   $��	37,98,0,0q�6B   $	��Top=�6U   $��29��6m   $��93��6y   �� 5   
   $��Оригинал��6   $
��Left=�6#   $��
37,131,0,0q�6>   $	��Top=�6R   $��30��6j   $��93��6v   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��43��6@   $��
31,368,0,0q�6L   $	��Top=�6`   $	��111��6x   6�   �� 5   
   -   5        $��Отменить��5      $
��Left=�6$   $��43��6?   $��153,368,0,0q�6K   $	��Top=�6`   $	��111��6x   6�   �� 5   
   $
��Left=�6   $��135,167,0,0q�6-   $	��Top=�6B   $	��120��6Z   $��30��6f   ��6r   �� $ UI��$ CurrentExhibit.width��� 5   
   $��Ширина, см��6   $
��Left=�6%   $��
37,167,0,0q�6@   $	��Top=�6T   $��30��6l   $��93��6x   �� 5   
   $��Высота, см��6   $
��Left=�6%   $��
37,202,0,0q�6@   $	��Top=�6T   $��30��6l   $��93��6x   �� 5   
   $
��Left=�6   $��135,202,0,0q�6-   $	��Top=�6B   $	��120��6Z   $��30��6f   ��6r   �� $ UI��$ CurrentExhibit.height��� 5   
   -   5        $ CanvasTypeComboBox��5      
 �� SelectedIndex$
 0��6/   $��135,237,38.333,153.667q�6�    �� SelectedValue 6A   �� $ UI��$  CurrentExhibit.canvas_type�.@�5      �� .��6   
Холст6"   �� 5      .��6   Бумага6#   �� 5      .��6   Дерево6#   �� 5      .��6   Другое6#   5      �� 5   
   $��Тип холста��6   $
��Left=�6%   $��
37,237,0,0q�6@   $	��Top=�6T   $��30��6l   $��93��6x   �� 5   
   -   5        $ PaintTypeComboBox��5   %   $
 0��6   $��135,272,38.333,118.667q�6�    6@   �� *CurrentExhibit.paint_type+$ UI��.@�5      �� $��
Масло��6   �� 5       $��Свинцовая��6   �� 5!      $��Акварель��6   �� 5"      $��
Гуашь��6   �� 5#      $��Другое��6   5$      �� 5%   
   $��Тип краски��6   $
��Left=�6%   $��
37,272,0,0q�6@   $	��Top=�6T   $��30��6l   $��93��6x   �� 5&   
   $��135,307,38.333,83.667q�6T   $
 name��6�   $ id��6�    6   �� *CurrentExhibit.hall_id+$ UI����6s   ��   hallViewSource# [ 5'      �� 5(   
   $��Зал��6   $
��Left=�6   $��
37,307,0,0q�69   $	��Top=�6M   $��30��6e   $��93��6q   5)      5*      