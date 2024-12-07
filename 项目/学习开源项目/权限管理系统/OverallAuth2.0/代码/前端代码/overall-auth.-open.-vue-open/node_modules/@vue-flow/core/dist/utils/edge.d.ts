import type { Actions, EdgePositions, GraphEdge, GraphNode, HandleElement, Rect, ViewportTransform, XYPosition } from '../types'
import type { Position } from '../types'

export declare function getHandlePosition(position: Position, rect: Rect, handle: HandleElement | null): XYPosition
export declare function getHandle(bounds?: HandleElement[], handleId?: string | null): HandleElement | null
export declare function getEdgePositions(
  sourceNode: GraphNode,
  sourceHandle: HandleElement | null,
  sourcePosition: Position,
  targetNode: GraphNode,
  targetHandle: HandleElement | null,
  targetPosition: Position,
): EdgePositions
interface IsEdgeVisibleParams {
  sourcePos: XYPosition
  targetPos: XYPosition
  sourceWidth: number
  sourceHeight: number
  targetWidth: number
  targetHeight: number
  width: number
  height: number
  viewport: ViewportTransform
}
export declare function isEdgeVisible({
  sourcePos,
  targetPos,
  sourceWidth,
  sourceHeight,
  targetWidth,
  targetHeight,
  width,
  height,
  viewport,
}: IsEdgeVisibleParams): boolean
export declare function getEdgeZIndex(edge: GraphEdge, findNode: Actions['findNode'], elevateEdgesOnSelect?: boolean): number
export {}
