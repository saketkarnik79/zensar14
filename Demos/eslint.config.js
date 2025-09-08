import eslintRecommended from "@eslint/js";;

export default [
  eslintRecommended.configs.recommended,
  {
    languageOptions:{
      ecmaVersion: 2024,
      sourceType: "module",
      globals: {
        window: "readonly",
        document: "readonly",
        navigator: "readonly"
    }
  },
  rules:{
    semi: ["error", "always"],
    quotes: ["error", "double"]
  }
}];

