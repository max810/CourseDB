   M S B A M L   `   `   `  ����C  ?CourseDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CourseDBCourseDB  5   	   !    CourseDB.ArtistFilterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CourseDB     5   	   -   5          � Title$  ArtistFilterWindow��5   	   $	��300��6$   $	��450��61    � 
ResizeMode$ NoResize=�6V   .��5	      �  � RowDefinitions 5
   
   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ ListOfFilters��5   9   $��0,0,0.333,37.667q�6P   ��6   �� *Delegates.Keys+5      �� 5   
   $��1��6   $	��Top=�6%   $
��auto��6=   $��Center=�6J    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 25, 0, 25, 0q�6/   6F   �� 5       � ��$ 50��6.   6;   �� 5       � ��$ 18(�61   6>   5      5      .+�5      �� $��Center=�6   $��31��61   $
��90,0q�6=   $	��Top=�6K   .��6c   Годы жизни6o   �� 5      	 �� Orientation$	 
Horizontal=�6   .+�5      �� -   5        
 ��Name$
 FromYear��5      .��6,   *6/   �� 5      $��18(�6   ПО6/   �� 5      -   5        $
 ToYear��5      .��6*   *6-   5       �� 5!      $��Center=�6   $��0, 10, 0, 0q�61   .��6F   !Название фильтра6X   �� 5"      -   5        $
 
FilterName��5"      $	��100��6*   .��66   Фильтр06?   5#      �� 5$   
   -   5        $��1��5$      $	��100��6!   $��50��6-   $#��Добавить фильтр��69   $��4.667,183,117.333,37.667q�6S   6�   �� 5%   
   -   5        $��1��5%      $��50��6!   $!��Удалить фильтр��6-   $��111.667,183,0.333,37.667q�6F   6h   	� 5&   
   -   5         d� 	IsChecked$
 TrueY�5&      $��Все сразу��6'    	� 	GroupName$ 
FilterMode��6;   $
��Left=�6R   $��
10,246,0,0q�6m   $	��Top=�6�   6�   	� 5'   
   -	   5        $��Хотя бы один��5'      $ 
FilterMode��6-   $
��Left=�6D   $��105,246,0,0q�6_   $	��Top=�6t   6�   5(      5)      