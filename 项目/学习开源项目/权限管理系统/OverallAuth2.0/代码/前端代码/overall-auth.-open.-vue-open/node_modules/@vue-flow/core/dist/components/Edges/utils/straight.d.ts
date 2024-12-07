export interface GetStraightPathParams {
  sourceX: number
  sourceY: number
  targetX: number
  targetY: number
}
export declare function getStraightPath({
  sourceX,
  sourceY,
  targetX,
  targetY,
}: GetStraightPathParams): [path: string, labelX: number, labelY: number, offsetX: number, offsetY: number]
