# MA_Editor

## Usage Artist

- Assets --> Create --> Texture2DArray.

## Usage Programmers

- Runtime
  1. Create SciptableObject instance of type Texture2DArrayAsset.
  2. Fill in variables.
  3. Apply to generate the texture (e.g. myTexture2DArray.Apply()).
  
## Limitations

- All textures must have the same format.
- All textures must have the same size.
- When adding/removing textures from an existing asset, it needs to be reset, dependencies will be lost.
