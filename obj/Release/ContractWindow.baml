   M S B A M L   `   `   `  ���� C  ?UsersApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:UsersAppUsersApp      UsersApp.ContractWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:UsersApp       � WindowStartupLocation$  CenterScreen=� � WindowState$ 	Maximized=� � Title$E ?Приложение для страховой компании��$	��900��$
��1440��.��� ���#3A2E85.+��� $
��1000��$��20q�
�������$��Center=� �� Padding$ 40q�$
��1210��._��� .+��� $��64(�$��0 0 0 40q�$
��Bold"�'%Заключение договора�� $��0 0 0 5q�$��24(�$
��Bold"�Номер договора�� -    ��Name$ ContractNumField��$��0 0 0 20q� �� Padding$ 0 3 0 3q�$��18(��� $��0 0 0 5q�$��24(�$
��Bold"�Дата заключения�� -   $ ContractDate��$��0 0 0 20q�$ 0 3 0 3q�$��18(��� $��0 0 0 5q�$��24(�$
��Bold"�
Сумма�� -    ��Name$ ContractPrice��$��0 0 0 20q�$��0,0,0,1q�$��0 3 0 3q�$��18(��� $��0 0 0 5q�$��24(�$
��Bold"�Вид страхования�� -    ��Name$ TypeContract��$��0 0 0 5q�$��18(�$��3 3 3 3q�.@��� .�� Автострахование�� .�� Здравоохранение�� .��Имущественное�� .�� Ответственность�� .��Бизнес�� .��#!Несчастный случай�� -   $ TarifPercent��$)��#Процентная ставка: ��$y�Hidden=�$��0 0 0 10q�$��10(�$��Italic$�
���  ��� .+��� .+��� $��0 0 0 5q�$��24(�$
��Bold"�Филиал�� -   $ FilialContract��$��0 0 0 20q�$��18(�$��3 3 3 3q�$	��550��$
��Left=��� $��Right=�.+��� $��0 0 0 5q�$��24(�$
��Bold"�
Агент�� -   $ AgentContract��$��0 0 0 20q�$��18(�$��3 3 3 3q�$	��550��$
��Left=��� $��0 0 0 5q�$��24(�$
��Bold"�Итоговая сумма�� -   $ 
FinalPrice��$��0 0 0 20q�$ 0 3 0 3q�$��18(�� .+��� -	   $��40��$��14(����#2C17B1
�������$
��Left=�$��90��.��
Назад�� -
   $��40��$��14(����#2C17B1
�������$��Right=�$��90��.��Заключить