variable "vpc_id" {
  type = string
  //fake
  default = "vpc-08644e01225b62e6b"
}
variable "private_subnets" {
  type = list(any)
  //fake
  default = [
      "subnet-049afe01c75014012",
      "subnet-0b6003c8d3a8b2cad"
  ]
}