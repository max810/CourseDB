   M S B A M L   `   `   `  ����C  ?CourseDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CourseDBCourseDB  5   	       CourseDB.ArtistEditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CourseDB     5   	   -   5        $��UI��5   8     � Title$  ArtistWindow��6	   $	��400��6   $	��300��6,    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ Right=�6;   6K   �� 5       � ��$	 Top=�69   6G   5      5      .��5      � $��0,0,0.333,-3.333q�6   $	��274��6%   $	��Top=�62   .+�5   
   �� $	��100��6   $
��Left=�6!   $��28��6�   $��	98,65,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   ��6<   ��  �� ElementName$ UI�� �� Path$ CurrentArtist.full_name� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��70��6v   $��
98,166,0,0q�6�   $
 Wrap=�6�   $��Stretch=�6�   $��Stretch=�6�   ��6   �� $ UI��$ CurrentArtist.biography�$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6�   $��	98,98,0,0q�6�   $	��Top=�6�   $��29��6�   	   SelectedDate	 6   �� $ UI��$! CurrentArtist.date_of_birth�$ PropertyChanged=�6�     5   
   $
��Left=�6�   $��
98,131,0,0q�6�   $	��Top=�6�   $��30��6�   	 6   �� $ UI��$! CurrentArtist.date_of_death�$ PropertyChanged=�6�   �� 5   
   $��Полное имя��6   $
��Left=�6%   $��	10,65,0,0q�6@   $	��Top=�6S   $��28��6k   �� 5   
   $��Дата рождения��6   $
��Left=�6(   $��	10,98,0,0q�6C   $	��Top=�6V   $��29��6n   �� 5   
   $��Дата смерти��6   $
��Left=�6&   $��
10,131,0,0q�6A   $	��Top=�6U   $��30��6m   �� 5   
   $��Биография��6   $
��Left=�6$   $��
10,185,0,0q�6?   $	��Top=�6S   $��28��6k   �� 5   
   $��Художник��6   $��18(�6#   $
��Left=�61   $��	98,10,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��43��6@   $��35,303,0,-72q�6L   $	��Top=�6b   6z   �� 5   
   -   5        $��Отменить��5      $
��Left=�6$   $��43��6?   $��151,303,0,-72q�6K   $	��Top=�6b   6z   5      5      