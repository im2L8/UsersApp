   M S B A M L   `   `   `  ����C  ?UsersApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:UsersAppUsersApp  5   	       UsersApp.FilialsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   (localclr-namespace:UsersApp     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowState$ 	Maximized=�5	   	    � Title$E ?Приложение для страховой компании��5
   	   $	��900��63   $
��1440��6@   .��5      � ���#3A2E85.+�5   
   �� $
��1000��6   $��20q�6!   
�������$��Center=�6@    �� Padding$ 40q�6[   $
��1210��6h   ._�5      �� .+�5      � $��0 0 0 40q�6   .+�5      �� $
��Left=�6    $��64(�6;   $
��Bold"�6I   Список филиалов6l   �� 5      -   5        $��Right=�5   ?   $��14(�6[   ���#2C17B1
�������$	��100��6�   .��6�   Москва6�   �� 5      -   5        $
��Left=�5   =   $��14(�6X   ���#2C17B1
�������$	��100��6�   $��	914,0,0,0q�6�   .��6�   Код 5000+6�   �� 5      -   5        $
��Left=�5   :   $��14(�6U   ���#2C17B1
�������$	��100��6�   $��	797,0,0,0q�6�   .��6�   Обновить6�   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ FilialsData��5      $��0 0 0 20q�60   6D   � 5      .+�5      �� -   5        $��40��5      $��14(�6,   ���#2C17B1
�������$
��Left=�6b   $��90��6}   .��6�   
Назад6�   �� 5      -   5        $��40��5      $��14(�6,   ���#2C17B1
�������$��Center=�6b   $	��300��6   .��6�   Изменить данные6�   �� 5      -   5        $��40��5      $��14(�6,   ���#2C17B1
�������$��Right=�6b   $��90��6~   .��6�   Добавить6�   5      5      5      5      5      