module.exports = {
  transpileDependencies: ['vuetify'],

  devServer: {
    https: false,
  },

  configureWebpack: {
    devtool: 'source-map',
  },

  pluginOptions: {
    i18n: {
      locale: 'it',
      fallbackLocale: 'it',
      localeDir: 'locales',
      enableInSFC: false,
      includeLocales: false,
      enableBridge: true,
    },
  },
};
