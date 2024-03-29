module.exports = {
  root: true,

  env: {
    node: true,
  },

  parserOptions: {
    parser: 'babel-eslint',
  },

  rules: {
    'no-null/no-null': 'off',
    'linebreak-style': ['error', process.env.NODE_ENV === 'prod' ? 'unix' : 'windows'],
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'import/no-extraneous-dependencies': ['error', { devDependencies: true }],
    'no-tabs': ['error', { allowIndentationTabs: true }],
    'max-len': ['error', { code: 120 }],
    'operator-linebreak': 0,
    'prettier/prettier': [
      'warn',
      {
        endOfLine: 'auto',
        singleQuote: true,
        trailingComma: 'es5',
        printWidth: 120,
        jsxSingleQuote: false,
      },
    ],
  },
  extends: ['plugin:vue/essential', 'eslint:recommended', '@vue/prettier', '@vue/airbnb'],
};
