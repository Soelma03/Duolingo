   M S B A M L   `   `   `  ����N  JKursovaya(Duolingo), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Kursovaya_Duolingo_Kursovaya_Duolingo_  5   	   $    Kursovaya_Duolingo_.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Kursovaya_Duolingo_     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��700��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ CategoryComboBox��5
      $
��Left=�6-   $��	34,67,0,0q�6H   $	��Top=�6[   $	��120��6s    �� SelectedIndex$ 0��6   .@�5      �� $��Животные��6   �� 5      $��Еда��6   �� 5      $��Транспорт��6   �� 5      $��
Цвета��6   5      �� 5   
   -   5         ��Name$ 	AddButton��5      $!��Добавить слово��6$   $��513,139,56,0q�6`   $	��Top=�6v   $��58��6�   ��6=   �� *AddWordCommand+6�   �� 5   
   -   5         ��Name$ CorrectAnswersLabel��5      $,��&Правильных ответов: 0��6-   $��497,299,40,0q�6M   $	��Top=�6c   $��32��6{   �� 5   
   -   5        $ TotalAnswersLabel��5      $"��Всего ответов: 0��6+   $��497,336,40,0q�6F   $	��Top=�6\   $��32��6t   �� 5   
   -   5        $ 
LoadButton��5      $#��Загрузить слова��6%   $
��Left=�6?   $��294,195,0,0q�6Z   $	��Top=�6o   $��49��6�   $	��176��6�   6�   �� 5   
   -   5        $ StartTrainingButton��5      $'��!Начать тренировку��6.   $
��Left=�6J   $��294,290,0,0q�6e   $	��Top=�6z   $��64��6�   $	��176��6�   6�   �� 5   
   -   5        $ ResetWordsButton��5      $!��Очистить слова��6+   $
��Left=�6D   $��294,102,0,0q�6_   $	��Top=�6t   $��27��6�   $	��176��6�   6�   �� 5   
   $
��Left=�6   $��	32,40,0,0q�6/   $
��Wrap=�6B   $$��Количество слов:��6V   $	��Top=�6n   �� 5   
   $
��Left=�6   $��
139,40,0,0q�6/   $
��Wrap=�6C   $	��Top=�6r   ��6W   �� *	WordCount+6r   �� 5   
   -   5         ��Name$ WordsListView��5      $��34,102,424,59q�6P   ��6*   �� *FilteredWords+ �� View 5      �� 5      .P�5      �� $��
Слово��6%    �� Width$ 90��6a    �� DisplayMemberBinding 64   �� *ForeignWord+6a   �� 5      $��Перевод��6%   $	 120��6c    66   �� *Translation+6c   5      5       �� 5!   
   -	   5        $ 
SaveButton��5!      $#��Сохранить слова��6%   $
��Left=�6?   $��294,139,0,0q�6Z   $	��Top=�6o   $��45��6�   $	��176��6�   6�   5"      5#      