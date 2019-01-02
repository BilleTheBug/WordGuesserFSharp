module Config

  let HIDDEN = '*'
  
  let CASE_SENSITIVE = false

  let ALLOW_BLANKS = false

  let HELP = false

  let MULTIPLE = false

  let WORDS_WITHOUT_SPACES = List.concat [WordType.CITIES;WordType.NAMES]

  let WORDS = List.concat [WordType.CITIES;WordType.NAMES; WordType.MOVIES]