   M S B A M L   `   `   `  ����?  ;Rene, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE.clr-namespace:Rene.CustomControl;assembly=ReneRene.CustomControl  5      G CReneConsumer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]>clr-namespace:ReneConsumer.CustomControl;assembly=ReneConsumerReneConsumer.CustomControl 5      K5clr-namespace:ReneConsumer.View;assembly=ReneConsumerReneConsumer.View 5      O7clr-namespace:ReneData.DataObject;assembly=ReneConsumerReneData.DataObject 5      M6clr-namespace:ReneConsumer.Model;assembly=ReneConsumerReneConsumer.Model 5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&    ReneConsumer.View.UserWindowView  �� 
TargetType �� Property �� Value �� 
TargetType � RowDefinitions �� Orientation    MinimiseCommand    MaximiseCommand    CloseCommand	 �� Path
 �� UpdateSourceTrigger    SaveCommand-  'ReneConsumer.CustomControl.UserDataList ��Name �� SelectionMode �� View �� DisplayMemberBinding �� Width   UserDataListActions �� CellTemplate   
AddCommand   UploadCommand   EditCommand   DeleteCommand�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6x,http://schemas.microsoft.com/winfx/2006/xaml   5      5cc.clr-namespace:Rene.CustomControl;assembly=Rene  5      Fccr>clr-namespace:ReneConsumer.CustomControl;assembly=ReneConsumer  5      =ccv5clr-namespace:ReneConsumer.View;assembly=ReneConsumer  5      >do7clr-namespace:ReneData.DataObject;assembly=ReneConsumer  5      <m6clr-namespace:ReneConsumer.Model;assembly=ReneConsumer  5      %
  '         '  /    &	  `	    �� 5
      "    6	   .�5      ��  � �� 5      �� 5      "   6   .R�5      �� 
�������._�5      �  5   	   �� 5   
   $��* �6   �� 5   
   $
��Auto �6   .+�5   	   �� .+�5   
   �� $ 
Horizontal=�6   $��Right=�6.   .+�5      �� $��_��6   #��Z 6   �� 5      $��[]��6   #��Z 6   �� 5      $��X��6   #��Z 6   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $��
First Name��6   $	��100��6'   �� 5      ��6   �� $	 AddEdit.User.FirstName�$
 PropertyChanged=�5      �� 5    
   $ 
Horizontal=�6   .+�5!      �� $��	Last Name��6   $	��100��6&   �� 5"      ��6   �� $	 AddEdit.User.LastName�$
 PropertyChanged=�5#      �� 5%   
   $ 
Horizontal=�6   .+�5&      �� $��	User Name��6   $	��100��6&   �� 5'      ��6   �� $	 AddEdit.User.Username�$
 PropertyChanged=�5(      �� 5*   
   $ 
Horizontal=�6   .+�5+      �� $��Password��6   $	��100��6%   �� 5,      ��6   �� $	 AddEdit.User.Password�$
 PropertyChanged=�5-      5.   
   �� 50   	   $ 
Horizontal=�6   $��1��6-   $��Right=�6:   .+�51   
   �� $
��Save��6   #��Z 6    �� 52   
   $��Cancel��6   #��Z 6"   53   
   54   	   55      56      58      59      �� 5;      "   6	   .�5<      ��  � �� 5=      �� 5>      "  6   .R�5?      �  5@      �� 5A   	   $
��Auto �6   �� 5B   	   $��10 �6   �� 5C   	   $
��Auto �6   �� 5D   	   $��10 �6   �� 5E   	   $
��Auto �6   .+�5H      �� $ 	PART_List��5I      #��z��5J      # z 5K       5M   	   �� 5N   
   .P�5O      �� 	FirstName��$��
First Name��6-    6A   �� $	 	FirstName�$
 PropertyChanged=��� 5P      LastName��$��	Last Name��6,    6?   �� $	 LastName�$
 PropertyChanged=��� 5Q      Username��$��Username��6,    6>   �� $	 Username�$
 PropertyChanged=��� 5R      Password��$��Password��6,    6>   �� $	 Password�$
 PropertyChanged=��� 5S      Actions��$ 75��6+   $��Actions��66   # �   6G   5T      5V   	   �� 5X      $��2��6   $��Add User��6   $��Right=�6/   $	��100��6K   #��Z 6W   �� 5Z      $��4��6   $��Upload File��6   $��Right=�62   $	��100��6N   #��Z 6Z   5[      5\      5^      5_      �� 5a      .R�5b      �� $ 
Horizontal=�6   .+�5c      �� $
��Edit��6   #��Z 6   �� 5d      $��Delete��6   #��Z 6   5e      5f      5h      