# clear_measure_homework
    Class to print name paired with a value that is divisible by a number evenly
    For example: if the name is 'Name1' and value is 5, then the name will print 
    when the counter is divisible evenly by that number.
    There are 2 and only 2 name/value pairs allowed.
    Exceptions are thrown when:
    1) The UpperBound is GT than the MaximumUpperBoundAllowed value in RickyBobbyArgument
    2) The UpperBound is GT the Page * PageCount value
    3) Any of the integer values in RickyBobbyArgument are < 0
    4) The count of ModNamePairs != 2
    The default MaximumUpperBoundAllowed value is 250,000
    
    Requirements
    1) Add Unit testing - completed
    2) Add flexibility for user to change names and factors
    3) Add ability to handle large upper bound values
    
    Note: The decision was made to use a pagination pattern to handle the larger size of the list created when there is a large upper bound set.
    Works by setting a page number and the number of items to show per page.
    
    
