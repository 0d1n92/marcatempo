module.exports = {
  transpileDependencies: ["vuetify"],
  devServer: {
    https: true,
  },
  configureWebpack: {
    devtool: 'source-map'
  }
};
