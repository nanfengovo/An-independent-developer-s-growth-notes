import type { FlowOptions, FlowProps, VueFlowStore } from '../types'

/**
 * Stores all currently created store instances
 */
export declare class Storage {
  currentId: number
  flows: Map<string, VueFlowStore>
  static instance: Storage
  static getInstance(): Storage
  set(id: string, flow: VueFlowStore): Map<string, VueFlowStore>
  get(id: string): VueFlowStore | undefined
  remove(id: string): boolean
  create(id: string, preloadedState?: FlowOptions): VueFlowStore
  getId(): string
}
export declare function useVueFlow(options?: FlowProps): VueFlowStore
