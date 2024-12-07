export declare enum ErrorCode {
  MISSING_VIEWPORT_DIMENSIONS = 'MISSING_VIEWPORT_DIMENSIONS',
  NODE_INVALID = 'NODE_INVALID',
  NODE_NOT_FOUND = 'NODE_NOT_FOUND',
  NODE_MISSING_PARENT = 'NODE_MISSING_PARENT',
  NODE_TYPE_MISSING = 'NODE_TYPE_MISSING',
  NODE_EXTENT_INVALID = 'NODE_EXTENT_INVALID',
  EDGE_INVALID = 'EDGE_INVALID',
  EDGE_NOT_FOUND = 'EDGE_NOT_FOUND',
  EDGE_SOURCE_MISSING = 'EDGE_SOURCE_MISSING',
  EDGE_TARGET_MISSING = 'EDGE_TARGET_MISSING',
  EDGE_TYPE_MISSING = 'EDGE_TYPE_MISSING',
  EDGE_SOURCE_TARGET_SAME = 'EDGE_SOURCE_TARGET_SAME',
  EDGE_SOURCE_TARGET_MISSING = 'EDGE_SOURCE_TARGET_MISSING',
  EDGE_ORPHANED = 'EDGE_ORPHANED',
}
declare const messages: {
  readonly MISSING_VIEWPORT_DIMENSIONS: () => string
  readonly NODE_INVALID: (id?: string) => string
  readonly NODE_NOT_FOUND: (id: string) => string
  readonly NODE_MISSING_PARENT: (id: string, parentId: string) => string
  readonly NODE_TYPE_MISSING: (type: string) => string
  readonly NODE_EXTENT_INVALID: (id: string) => string
  readonly EDGE_INVALID: (id: string) => string
  readonly EDGE_SOURCE_MISSING: (id: string, source: string) => string
  readonly EDGE_TARGET_MISSING: (id: string, target: string) => string
  readonly EDGE_TYPE_MISSING: (type: string) => string
  readonly EDGE_SOURCE_TARGET_SAME: (id: string, source: string, target: string) => string
  readonly EDGE_SOURCE_TARGET_MISSING: (id: string, source: string, target: string) => string
  readonly EDGE_ORPHANED: (id: string) => string
  readonly EDGE_NOT_FOUND: (id: string) => string
}
export declare class VueFlowError<T extends ErrorCode = ErrorCode> extends Error {
  code: T
  constructor(
    code: T,
    ...args: (typeof messages)[T] extends (...args: any[]) => string ? Parameters<(typeof messages)[T]> : never
  )
}
export {}
