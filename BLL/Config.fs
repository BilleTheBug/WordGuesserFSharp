module Config
  //Representation of unguessed characters in the UI
  let HIDDEN = '*'
  
  //If true, comparisons will be case sensitive
  let CASE_SENSITIVE = false

  //If true, words with blanks will be allowed
  let ALLOW_BLANKS = false

  //If true, the Help method will be available for the user
  let HELP = true

  //Not yet implemented
  let MULTIPLE = false

  //List of words NOT containing spaces
  let WORDS_WITHOUT_SPACES = List.concat [WordType.CITIES;WordType.NAMES]

  //List of both words containing- and without spaces
  let WORDS = List.concat [WordType.CITIES;WordType.NAMES; WordType.MOVIES]