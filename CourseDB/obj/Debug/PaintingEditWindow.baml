   M S B A M L   `   `   `  ����C  ?CourseDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CourseDBCourseDB  5   	   !    CourseDB.PaintingEditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CourseDB     5   	   -   5          �Name$  UI��5   2    � Title$ Картина��6	   $	��375��6   $	��300��6&    � 	Resources 5	       �� 
TargetType �� Property �� Value��%a   '��       �� 5
   
   " ��6   .�5      ��  � ��UI��$ Right=�6;   6I   5      5      .��5      � .+�5   
   �� $��Картина��6   $��18(�6"   $��Center=�60   $
��0,10q�6M   $	��Top=�6[   �� 5   
   $
��Left=�6   $��28��6�   $��
135,65,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6-   ��  �� ElementName$ UI�� �� Path$ CurrentPainting.name�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5   
   $
��Left=�6~   $��
135,98,0,0q�6�   $	��Top=�6�   $	��120��6�   $��29��6�   ��6   �� $ UI��$&  CurrentPainting.year_of_creation�$	 PropertyChanged=�6�   �� 5   
   $
��Left=�6�   $��135,131,0,0q�6�   $	��Top=�6�   $	��120��6�   $��30��6�   
 �� DisplayMemberPath$
 	full_name��6�    �� SelectedValuePath$ id��6  ��6   ��    artistViewSource �� Source# [   �� SelectedValue 6T   �� $ UI��$ CurrentPainting.artist_id�6  �� 5   
   $��Название��6   $
��Left=�6#   $��	37,65,0,0q�6>   $	��Top=�6Q   $��28��6i   $��93��6u   �� 5   
   $��Год создания��6   $
��Left=�6'   $��	37,98,0,0q�6B   $	��Top=�6U   $��29��6m   $��93��6y   �� 5   
   $��
Автор��6   $
��Left=�6    $��
37,131,0,0q�6;   $	��Top=�6O   $��30��6g   $��93��6s   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��43��6@   $��
31,271,0,0q�6L   $	��Top=�6`   $	��111��6x   6�   �� 5   
   -   5        $��Отменить��5      $
��Left=�6$   $��43��6?   $��153,271,0,0q�6K   $	��Top=�6`   $	��111��6x   6�   �� 5   
   $
��Left=�6�   $��135,167,0,0q�6�   $	��Top=�6�   $	��120��6�   $��30��6�   $

 name��6	  $ id��6"  ��6   ��   art_movementViewSource# [  6Z   �� $ UI��$% CurrentPainting.art_movement_id�6"  �� 5   
   $��Направление��6   $
��Left=�6&   $��
37,167,0,0q�6A   $	��Top=�6U   $��30��6m   $��93��6y   �� 5   
   $��Изображение��6   $
��Left=�6&   $��
37,202,0,0q�6A   $	��Top=�6U   $��30��6m   $��93��6y   �� 5   
   -   5        $��Choose file��5      $
��Left=�6'   $��135,202,0,0q�6B   $	��Top=�6W   $	��120��6o   $��30��6{   6�   5      5      