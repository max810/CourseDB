   M S B A M L   `   `   `  ����C  ?CourseDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CourseDBCourseDB  5   	   #    CourseDB.PaintingFilterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CourseDB     5   	   -   5        $��UI��5   V     � Title$  PaintingFilterWindow��6	   $	��450��6&   $	��450��63    � 
ResizeMode$ NoResize=�6y   .��5	      � .+�5
   
   �� $��216,6,0.333,261.667q�6^   {�6   ��  �� ElementName$ MovementChoiceCheckBox�� �� Path$ 	IsChecked�.+�5      �� .��6   20Принадлежит к направлению6/   �� 5      -   5        $��ChosenMovement��5   ^    �� DisplayMemberPath$
 name��6t    �� SelectedValuePath$ id��6�   ��6   ��    art_movementViewSource �� Source# [  6�   5      �� 5   
   -   5         ��Name$ ListOfFilters��5      $��0,0,271.333,29.667q�6)   �� 5   
   -   5        $��50��5      $#��Добавить фильтр��6   $��200,361,128.333,9.667q�67   {�5      `� 5        AnyBoolConverter `� 	Converter# [ 6   .1�5      �� $ MovementChoiceCheckBox��6   $ 	IsChecked�6C   6V   �� 5      $ YearChoiceCheckBox��6   $ 	IsChecked�6?   6R   5      5      �� 5   
   -   5        $��50��5      $!��Удалить фильтр��6   $��320,361,28.333,9.667q�66   6T   �� 5   
   $	��Top=�6Z   $	��219��6r   $��Center=�6~   $	��126��6�   $��216,172,8.333,0q�6�   {�6   �� $ YearChoiceCheckBox��$ 	IsChecked�	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%�   '��       �� 5      "
 ��6   .�5      ��  � ��$ 25, 0, 25, 0q�6/   �� 5       � ��$ 50��6.   �� 5       � ��$ 18(�61   5      5       .+�5!      �� $��Center=�6   $��31��61   $��0q�6=   $	��Top=�6H   $$��Создана в период��6`   $	��118��6{   �� 5"       �� Orientation$ 
Horizontal=�6   .+�5#      �� -   5         ��Name$ FromYear��5#   $   $��*��6   6$   �� 5$      $��18(�6   �� 6+   $
�ПО��6/   6<   �� 5%      -   5        $ ToYear��5%   $   $��*��6   6$   5&      �� 5'      $��Center=�6   $��0, 10, 0, 0q�61   $%��Название фильтра��6F   5(      �� 5)   
   -   5        $ 
FilterName��5)      $	��100��6&   $��Фильтр��62   $��264,305,79.333,85.667q�6@   �� 5*   
   -	   5         ��Name$ MovementChoiceCheckBox��5*   Z   $
��Left=�6   $��
187,88,0,0q�6.   $	��Top=�6B   6Z   �� 5+   
   -
   5        $ YearChoiceCheckBox��5+   [   $
��Left=�6   $��187,209,0,0q�6.   $	��Top=�6C   6[   	� 5,   
   -   5         d� 	IsChecked$
 TrueY�5,      $��Все сразу��6'    	� 	GroupName$ 
FilterMode��6;   $
��Left=�6R   $��
10,396,0,0q�6m   $	��Top=�6�   6�   	� 5-   
   -   5        $��Хотя бы один��5-      $ 
FilterMode��6-   $
��Left=�6D   $��
86,396,0,0q�6_   $	��Top=�6s   6�   5.      5/      