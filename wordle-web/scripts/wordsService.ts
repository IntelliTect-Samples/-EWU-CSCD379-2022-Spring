export abstract class WordsService {
  static getRandomWord(): string {
    return this.#words[Math.floor(Math.random() * this.#words.length)]
  }

  static validWords(guessedWord: string): string[] {
    const possibleWords: string[] = []
    while (guessedWord.includes('?')) {
      guessedWord = guessedWord.replace('?', '.')
    }
    const regex = new RegExp(guessedWord)

    this.#words.forEach((element) => {
      if (element.match(regex)) {
        possibleWords.push(element)
      }
    })
    return possibleWords
  }

  // From: https://github.com/kashapov/react-testing-projects/blob/master/random-word-server/five-letter-words.json
  static readonly #words: string[] = [
    'acorn',
    'acrid',
    'actor',
    'adept',
    'adobe',
    'adorn',
    'adult',
    'agent',
    'agony',
    'aisle',
    'alder',
    'alien',
    'alike',
    'alive',
    'alone',
    'aloud',
    'amber',
    'ample',
    'amuck',
    'angel',
    'angry',
    'ankle',
    'antic',
    'arise',
    'aspen',
    'aspic',
    'audio',
    'awful',
    'azure',
    'balmy',
    'bandy',
    'basic',
    'basin',
    'batch',
    'baton',
    'bawdy',
    'beady',
    'beamy',
    'beast',
    'being',
    'bight',
    'bigot',
    'binge',
    'bingo',
    'biped',
    'birch',
    'birth',
    'bison',
    'biter',
    'blame',
    'bland',
    'blank',
    'bleak',
    'bleat',
    'blind',
    'bloat',
    'blond',
    'blunt',
    'bodge',
    'bogie',
    'bogus',
    'boned',
    'bonus',
    'bound',
    'boxer',
    'braid',
    'brand',
    'brash',
    'brave',
    'brawl',
    'brawn',
    'brick',
    'brief',
    'brisk',
    'broad',
    'broke',
    'brute',
    'bugle',
    'built',
    'bulky',
    'burly',
    'bushy',
    'butch',
    'cadet',
    'cadre',
    'calyx',
    'camel',
    'caste',
    'cedar',
    'chaos',
    'chard',
    'cheap',
    'chest',
    'chief',
    'china',
    'chirp',
    'chive',
    'choir',
    'choky',
    'chore',
    'churl',
    'clave',
    'cleft',
    'clerk',
    'clove',
    'clown',
    'clung',
    'comer',
    'conga',
    'coral',
    'corny',
    'corps',
    'corse',
    'court',
    'couth',
    'cover',
    'covey',
    'crake',
    'cramp',
    'craps',
    'crash',
    'crawl',
    'crazy',
    'cream',
    'crime',
    'crimp',
    'croup',
    'crown',
    'crude',
    'cruel',
    'cruet',
    'crump',
    'crypt',
    'curia',
    'curst',
    'curve',
    'daily',
    'datum',
    'delta',
    'demon',
    'depth',
    'diary',
    'dicky',
    'dinar',
    'diner',
    'dinge',
    'disco',
    'diver',
    'dogma',
    'doing',
    'dough',
    'downy',
    'dowry',
    'dozen',
    'draft',
    'drake',
    'drift',
    'drove',
    'drunk',
    'ducat',
    'dumpy',
    'dusky',
    'dusty',
    'dwarf',
    'dying',
    'debut',
    'early',
    'elfin',
    'entry',
    'envoy',
    'epoch',
    'equal',
    'ergot',
    'ethic',
    'exact',
    'exist',
    'extra',
    'faint',
    'fairy',
    'faker',
    'fakir',
    'false',
    'fancy',
    'fated',
    'feint',
    'felon',
    'femur',
    'feral',
    'field',
    'fiend',
    'fiery',
    'filet',
    'final',
    'finch',
    'first',
    'fishy',
    'fitch',
    'fiver',
    'fixed',
    'fixer',
    'flair',
    'flaky',
    'flank',
    'flask',
    'flesh',
    'flint',
    'flirt',
    'flora',
    'fluid',
    'fluke',
    'flush',
    'forte',
    'forum',
    'fount',
    'frail',
    'frank',
    'frisk',
    'frond',
    'fusil',
    'fusty',
    'gamut',
    'gaper',
    'garth',
    'gaunt',
    'gauze',
    'genus',
    'getup',
    'giant',
    'glade',
    'gland',
    'glare',
    'gloat',
    'gnome',
    'grail',
    'grand',
    'grate',
    'grave',
    'gravy',
    'great',
    'grief',
    'groat',
    'group',
    'grove',
    'guild',
    'gumbo',
    'hardy',
    'haver',
    'hawse',
    'hazel',
    'heady',
    'heavy',
    'hoary',
    'honey',
    'horde',
    'hover',
    'human',
    'husky',
    'idler',
    'inert',
    'inlet',
    'irony',
    'ivory',
    'jerky',
    'jihad',
    'joust',
    'juicy',
    'jumbo',
    'knave',
    'labor',
    'laity',
    'laker',
    'large',
    'laser',
    'later',
    'latex',
    'laver',
    'leafy',
    'leaky',
    'lemon',
    'letch',
    'limbo',
    'lined',
    'liner',
    'lithe',
    'liver',
    'loath',
    'locus',
    'lofty',
    'logic',
    'lotus',
    'lover',
    'lower',
    'lucid',
    'lucky',
    'lumen',
    'lurid',
    'lusty',
    'lying',
    'lyric',
    'macro',
    'madly',
    'magus',
    'maize',
    'major',
    'manes',
    'mango',
    'manly',
    'manor',
    'manse',
    'maybe',
    'mealy',
    'meaty',
    'media',
    'medic',
    'midge',
    'miner',
    'minor',
    'mirth',
    'miser',
    'misty',
    'mixed',
    'mixer',
    'mocha',
    'modal',
    'model',
    'moist',
    'molar',
    'monad',
    'moral',
    'morel',
    'mould',
    'mousy',
    'mover',
    'movie',
    'mufti',
    'murky',
    'mushy',
    'music',
    'musty',
    'nadir',
    'naive',
    'naked',
    'nasty',
    'nates',
    'navel',
    'neigh',
    'nervy',
    'night',
    'noble',
    'noisy',
    'north',
    'noted',
    'nymph',
    'oared',
    'ocean',
    'ocher',
    'odium',
    'often',
    'olive',
    'omega',
    'opera',
    'optic',
    'ounce',
    'outer',
    'ovary',
    'ovine',
    'palsy',
    'panic',
    'pants',
    'party',
    'pasty',
    'paten',
    'peach',
    'pecan',
    'pedal',
    'penal',
    'phony',
    'piano',
    'piety',
    'piker',
    'pilot',
    'pinch',
    'pinky',
    'pious',
    'pithy',
    'plain',
    'plumb',
    'plush',
    'poker',
    'pokey',
    'polar',
    'polka',
    'porch',
    'porgy',
    'poser',
    'prawn',
    'prime',
    'primo',
    'privy',
    'prize',
    'prone',
    'prose',
    'proud',
    'proxy',
    'pubes',
    'pylon',
    'quack',
    'qualm',
    'quart',
    'quick',
    'quiet',
    'quint',
    'quirk',
    'quite',
    'quota',
    'rabid',
    'radix',
    'rapid',
    'ratio',
    'raven',
    'rayon',
    'ready',
    'regal',
    'reign',
    'reins',
    'relax',
    'relay',
    'relic',
    'rheum',
    'right',
    'rocky',
    'rogue',
    'roman',
    'rouge',
    'rough',
    'royal',
    'runic',
    'rusty',
    'sable',
    'sabre',
    'salon',
    'salty',
    'salvo',
    'sandy',
    'satin',
    'satyr',
    'saucy',
    'scald',
    'scaly',
    'scant',
    'scape',
    'scary',
    'scion',
    'scrim',
    'scrip',
    'setup',
    'shady',
    'shaky',
    'shank',
    'shard',
    'shine',
    'shiny',
    'shire',
    'shlep',
    'shoal',
    'shock',
    'short',
    'showy',
    'sigma',
    'siren',
    'skate',
    'skein',
    'skimp',
    'slate',
    'slave',
    'slick',
    'slimy',
    'sloth',
    'smock',
    'smoky',
    'snail',
    'snake',
    'snaky',
    'snowy',
    'soapy',
    'sober',
    'solar',
    'solid',
    'sough',
    'south',
    'spare',
    'spate',
    'spelt',
    'spent',
    'sperm',
    'spick',
    'spicy',
    'spiny',
    'splat',
    'splay',
    'split',
    'spore',
    'sport',
    'sprat',
    'sprue',
    'spume',
    'spunk',
    'squab',
    'squat',
    'squid',
    'stair',
    'stale',
    'stang',
    'stark',
    'steam',
    'stern',
    'stich',
    'stile',
    'stock',
    'stoic',
    'stole',
    'stoma',
    'stone',
    'straw',
    'stria',
    'stuck',
    'suite',
    'sulky',
    'sumac',
    'super',
    'swain',
    'swale',
    'swank',
    'sward',
    'swart',
    'swing',
    'sworn',
    'sylph',
    'synod',
    'syrup',
    'tache',
    'talon',
    'talus',
    'tango',
    'tawny',
    'teary',
    'tempo',
    'tenor',
    'thick',
    'thief',
    'thing',
    'think',
    'thong',
    'throb',
    'thunk',
    'tiger',
    'tiler',
    'timer',
    'tipsy',
    'tired',
    'topaz',
    'topic',
    'torus',
    'tough',
    'trace',
    'trial',
    'trice',
    'tripe',
    'trope',
    'truck',
    'truly',
    'trunk',
    'tuber',
    'tulip',
    'tumid',
    'tumor',
    'tuner',
    'tunic',
    'twice',
    'twink',
    'ultra',
    'umber',
    'umbra',
    'unfit',
    'unite',
    'upset',
    'urban',
    'valor',
    'velar',
    'velum',
    'venal',
    'video',
    'vinyl',
    'viola',
    'viper',
    'vista',
    'vital',
    'vixen',
    'vizor',
    'vocal',
    'vogue',
    'wader',
    'washy',
    'waste',
    'waver',
    'waxen',
    'weald',
    'weary',
    'weird',
    'welsh',
    'wench',
    'wheat',
    'whelk',
    'whist',
    'white',
    'wight',
    'wince',
    'windy',
    'wiper',
    'wired',
    'wizen',
    'world',
    'wormy',
    'worse',
    'worth',
    'wound',
    'woven',
    'wrath',
    'wrong',
    'yacht',
    'zebra',
  ]
}
